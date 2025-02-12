using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    public ParticleSystem explosion;

    private void OnCollisionEnter(Collision collision)
    {
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
