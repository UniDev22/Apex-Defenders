 using UnityEngine;
 using System.Collections;
 using System.Collections.Generic;
 
 
 [System.Serializable]
 public class Wave
 {
     public string name;  
     public float delay;
     public GameObject enemy;
     public int spawnCount;
 }
 
 
 
 public class EnemySpawner : MonoBehaviour
 {
     public List<Wave> waves;
     private Wave m_CurrentWave;
     public Wave CurrentWave { get {return m_CurrentWave;} }
     public Vector3 enemySpawn;
 
     IEnumerator SpawnLoop()
     {
         while(true)
         {
             foreach(Wave W in waves)
             {
                 m_CurrentWave = W;
                     if(W.delay > 0)
                         yield return new WaitForSeconds(W.delay);
                     if (W.enemy != null && W.spawnCount > 0)
                     {
                         for(int i = 0; i < W.spawnCount; i++)
                         {
                            Instantiate(W.enemy, enemySpawn, Quaternion.identity);
                         }
                     }
                 
                 // prevents crash if all delays are 0
             }
              // prevents crash if all delays are 0
         }
     }
     void Start()
     {
        
        StartCoroutine(SpawnLoop());
     }
 
 }