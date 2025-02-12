using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destroyables : MonoBehaviour
{
    public DestroyablesTypes Type;
    public float health;
    public ParticleSystem explosionparticle;

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<ShellController>())
        {
            if (health <= 0)
            {
                SpawnDamageParticles();
                Destroy(gameObject);
            }
            health -= 50f;
        }
    }

    private void SpawnDamageParticles()
    {
        Instantiate(explosionparticle, transform.position, Quaternion.identity);
    }
}
