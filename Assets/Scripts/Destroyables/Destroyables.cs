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
    private float damagePower;
    

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<ShellView>().getShellParentType() == ShellParentType.PLAYERTANK)
        {
            processDamage();
        }
    }
    
    private float inidamage()
    {
        TankView tankView = FindObjectOfType<TankView>();
        damagePower =  tankView.getDamagePower();
        return damagePower;
    }
    private void processDamage()
    {
        inidamage();
        if (health <= 0)
        {
            Destroy(gameObject);
            SpawnDamageParticles();
        }
        
        health -= damagePower;
        uIController.UpdateScoreText(damagePower);
    }
    
    private void SpawnDamageParticles()
    {
        Instantiate(explosionparticle, transform.position, Quaternion.identity);
    }
}
