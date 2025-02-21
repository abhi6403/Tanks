using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destroyables : MonoBehaviour, IDestroyables
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
    
    public float getDamagePower()
    {
        TankView tankView = FindObjectOfType<TankView>();
        damagePower =  tankView.getDamagePower();
        return damagePower;
    }
    public void processDamage()
    {
        
        if (health >= 0)
        {
            getDamagePower();
            health -= damagePower;
            uIController.UpdateScoreText(damagePower);
        }
        else
        {
            Destroy(gameObject);
            spawnDamageParticles();
        }
        
        
        
    }
    
    public void spawnDamageParticles()
    {
        Instantiate(explosionparticle, transform.position, Quaternion.identity);
    }
}
