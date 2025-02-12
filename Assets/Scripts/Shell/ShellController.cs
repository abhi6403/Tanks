using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    public ParticleSystem explosion;
    //public DestroyableItems destroyableItems;
    private void OnCollisionEnter(Collision collision)
    {
        /*if (destroyableItems != null)
        {
                if (destroyableItems.gameObject == collision.gameObject)
                {
                    Destroy(destroyableItems.gameObject);
                }
        }*/
        SpawnDamageParticles();
        Explode();
    }

    
    private void Explode()
    {
        Destroy(gameObject);
    }

    private void SpawnDamageParticles()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
    
    
}
