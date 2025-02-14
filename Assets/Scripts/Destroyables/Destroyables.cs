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
    private float damage;
    

    public void OnCollisionEnter(Collision other)
    {
        ShellView shell = other.gameObject.GetComponent<ShellView>();
        
        if (shell)
        {
            if (health <= 0)
            {
                SpawnDamageParticles();
                Destroy(gameObject);
            }
            health -= damage;
            uIController.UpdateScoreText(damage);
        }
    }

    public void setDamage(float _damage)
    {
        damage = _damage;
    }
    private void SpawnDamageParticles()
    {
        Instantiate(explosionparticle, transform.position, Quaternion.identity);
    }
}
