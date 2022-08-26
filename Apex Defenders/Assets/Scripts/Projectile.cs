using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public int pierce = 1;
    public float lifetime;
    public GameObject impact;
    public bool canSeek = false;
    public float explosionRadius = 0f;
    private Transform target;
    private int pierceCount;
    private float distThisFrame;
    private Vector3 dir;

    public void Seek(Transform _target){
        target = _target;
    } 
    void Update()
    {
        
        if(target != null){
            dir = target.position - transform.position;
            distThisFrame = speed * Time.deltaTime;

            if(dir.magnitude <= distThisFrame)
            {
                HitTarget();
            }        
        }

        transform.Translate(dir.normalized * distThisFrame, Space.World);
        if(canSeek){
            transform.LookAt(target);        
        }

    }
    private void Awake()
    {
        pierceCount = pierce;
        Destroy(gameObject, lifetime);
    }

    void HitTarget(){
        GameObject effect = (GameObject)Instantiate(impact, transform.position, transform.rotation);
        Destroy(effect, 2f);
        if(explosionRadius > 0f){
            Explode();
        }
        else{
            Damage(target);
        }
    }

    void Explode(){
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders){
            if(collider.tag == "Enemy"){
                Damage(collider.transform);
            }
            else{
                Destroy(gameObject);
            }
        }
    }

    void Damage(Transform enemy){
        Destroy(enemy.gameObject);
    }
}
