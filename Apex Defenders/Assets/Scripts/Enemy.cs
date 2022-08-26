using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent enemyAI;
    Transform targetPoint;
    public float speed;
    int defendPointHealth;

    
    void Awake()
    {
        enemyAI = GetComponent<UnityEngine.AI.NavMeshAgent> ();
        enemyAI.speed = speed;
        targetPoint = GameObject.FindGameObjectWithTag ("DefendPoint").transform;
        Vector3 dirToTarget = (targetPoint.position - transform.position).normalized;
        Vector3 targetPosition = targetPoint.position - dirToTarget;    
        if(targetPoint != null)
        {
            enemyAI.SetDestination(targetPosition);
        }                  
    }

    void Start()
    {
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "DefendPoint"){
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Projectile"){
            Destroy(gameObject);
        }
    }
}
[System.Serializable]
public class EnemyStats
{
    public Enemy enemy;
    public int enemyCount;
    public float spawnDelay;
    public int damage;
}
