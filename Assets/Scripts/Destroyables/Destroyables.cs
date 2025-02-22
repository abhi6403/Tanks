using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Destroyables : MonoBehaviour
{
    [SerializeField] private DestroyablesTypes Type;
    [SerializeField] private float health;
    [SerializeField] private ParticleSystem explosionparticle;
    [SerializeField] private UIController uIController;
    [SerializeField] private Slider healthSlider;
    private float damagePower;
    private ObjectsToBeDestroyed objectsToBeDestroyed;

    private void Start()
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
        objectsToBeDestroyed = FindObjectOfType<ObjectsToBeDestroyed>();
        objectsToBeDestroyed.AssignDestroyableObjects(this);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<ShellView>().GetShellParentType() == ShellParentType.PLAYERTANK)
        {
            processDamage();
        }
    }
    
    private float getDamagePower()
    {
        TankView tankView = FindObjectOfType<TankView>();
        damagePower =  tankView.GetDamagePower();
        return damagePower;
    }
    private void processDamage()
    {
        if (health >= 0)
        {
            getDamagePower();
            healthSlider.value -= damagePower;
            health -= damagePower;
            
            uIController.UpdateScoreText(damagePower);
        }
        else
        {
            SoundManager.Instance.Play(Sounds.BLAST);
            objectsToBeDestroyed.RemoveDestroyableObjects(this);
            Destroy(gameObject);
            spawnDamageParticles();
        }
        
    }
    
    private void spawnDamageParticles()
    {
        Instantiate(explosionparticle, transform.position, Quaternion.identity);
    }
}
