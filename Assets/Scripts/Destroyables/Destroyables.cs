using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Destroyables : MonoBehaviour, IDestroyables
{
    public DestroyablesTypes Type;
    public float health;
    public ParticleSystem explosionparticle;
    public UIController uIController;
    private float damagePower;
    [SerializeField] private Slider healthSlider;



    void Start()
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }
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
        TakeDamage(damagePower);
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

    public void TakeDamage(float damage)
    {
        healthSlider.value -= damage;
    }
    public void spawnDamageParticles()
    {
        Instantiate(explosionparticle, transform.position, Quaternion.identity);
    }
}
