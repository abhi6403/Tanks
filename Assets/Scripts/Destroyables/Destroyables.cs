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
        ShellView shell = other.gameObject.GetComponent<ShellView>();
        
        if (shell)
        {
            processDamage();
        }
    }
    
    public float initializeDamage(TankTypes tankType)
    {
        switch (tankType)
        {
            case TankTypes.REDTANK:
                damagePower = 50f;
                Debug.Log("Damage Power: " + damagePower);
                break;
            case TankTypes.GREENTANK:
                damagePower = 20f;
                Debug.Log("Damage Power: " + damagePower);
                break;
            case TankTypes.BLUETANK:
                damagePower = 15f;
                Debug.Log("Damage Power: " + damagePower);
                break;
        }
        
        return damagePower;
    }

    private void processDamage()
    {
        TankView tankController = FindObjectOfType<TankView>();
        initializeDamage(tankController.getTankType());
        
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
