using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private TowerBlueprint towerToBuild;

    private void Awake()
    {
        instance = this;
    }




    public bool CanBuild {get { return towerToBuild != null;}}

    public void BuildTower(GroundPlane plane){
        GameObject tower = (GameObject)Instantiate(towerToBuild.prefab, plane.worldPos, transform.rotation);
        plane.tower = tower;
    }

    public void SelectTowerToBuild(TowerBlueprint tower){
        towerToBuild = tower;
    }
}
