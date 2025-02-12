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
    public UIController uIController;
    private float damagePower = 50f;
    

    public void OnCollisionEnter(Collision other)
    {
        ShellController shell = other.gameObject.GetComponent<ShellController>();
        
        if (shell)
        {
            if (health <= 0)
            {
                SpawnDamageParticles();
                Destroy(gameObject);
            }
            health -= damagePower;
            uIController.UpdateScoreText(damagePower);
        }
    }

    private void SpawnDamageParticles()
    {
        Instantiate(explosionparticle, transform.position, Quaternion.identity);
    }
}
