using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public Transform muzzle;
    private Transform target;
    private float shortestDistance;
    public GameObject projectilePrefab;

    public Color radiusColor;
    public string enemyTag = "Enemy";

    public float range = 15f;
    public float firerate = 1f;
    public float turnSpeed = 10f;

    private float fireCountdown;
    private void Awake()
    {
        fireCountdown = firerate;
    }

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0, .35f);
    }

    void UpdateTarget(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies){
            float distToTarget = Vector3.Distance(transform.position, enemy.transform.position);
            if(distToTarget < shortestDistance){
                shortestDistance = distToTarget;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range){
            target = nearestEnemy.transform;
        }
        else{
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null){
            Vector3 dir = target.position - transform.position;
            Quaternion lookRot = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRot, Time.deltaTime * turnSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);        
        }

        if(Input.GetKeyDown(KeyCode.Backspace)){
            Destroy(gameObject);
        }


        if(fireCountdown <= 0 && shortestDistance <= range){
            Shoot();
            fireCountdown = firerate;
        }

        fireCountdown -= Time.deltaTime;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = radiusColor;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Shoot(){
        GameObject spawnProjectile = (GameObject)Instantiate(projectilePrefab, muzzle.transform.position, muzzle.transform.rotation);
        Projectile projectile = spawnProjectile.GetComponent<Projectile>();
        if(projectile != null){
            projectile.Seek(target);
        }
    }
}
