using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;

public class GroundPlane : MonoBehaviour
{
    public GameObject tower;
    [HideInInspector]
    public Vector3 worldPos;
    Vector3 mousePos;

    BuildManager buildManager;
    Shop shop;

    void Start()
    {
        buildManager = BuildManager.instance;
        shop = GetComponent<Shop>();
    }
    void Update()
    {
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        if(Input.GetKey("1")){
            buildManager.SelectTowerToBuild(shop.standardBot);
        }
        if(Input.GetKey("2")){
            shop.SelectMissileBot();
        }
    }
    void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }
        if(!buildManager.CanBuild){
            return;
        }
        #region Setting up mouse Pos to world Pos
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit; 
        if(Physics.Raycast(ray, out hit, 1000f)){
            worldPos = hit.point;
        }
        else{
            worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        }
        #endregion
        //if(PlayerStats.money < buildManager.cost)

        buildManager.BuildTower(this);
    }
    void OnMouseUp()
    {
        buildManager.SelectTowerToBuild(null);
    }

}
