using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendPoint : MonoBehaviour
{
    public int startingHealth = 200;
    int health;

    private void Awake()
    {
        health = startingHealth;                
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if(health <= 0){
            Destroy(gameObject);
        }
    }

}
