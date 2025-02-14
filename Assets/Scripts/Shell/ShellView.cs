using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellView : MonoBehaviour
{
    [SerializeField]private ParticleSystem shellExplosion;
    private ShellController shellController;
    private Rigidbody shellRigidbody;
    private Destroyables destroyables;

    private void Start()
    {
        destroyables = FindObjectOfType<Destroyables>();
    }

    public void SetShellController(ShellController _shellController)
    {
        shellController = _shellController;
    }
    private void OnCollisionEnter(Collision collision)
    {
        CollisionWithDestroyables();
        SpawnDamageParticles();
        Destroy(gameObject);
    }

    private void CollisionWithDestroyables()
    {
        float explosionRadius = shellController.getExplosionRadius();
        float explosionForce = shellController.getExplosionForce();

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        for (int i = 0; i < colliders.Length; i++)
        {
            //Rigidbody rigidbody = colliders[i].GetComponent<Rigidbody>();
            
            Destroyables destroyables = colliders[i].GetComponent<Destroyables>();

            if (destroyables != null)
            {
                float damage = ProcessCollisionToDestroyables(explosionForce, explosionRadius);
                this.destroyables.setDamage(damage);
            }
        }
    }
    private float ProcessCollisionToDestroyables(float explosionForce, float explosionRadius)
    {
        shellRigidbody.AddExplosionForce(explosionForce,transform.position,explosionRadius);
        float damage = CalculateDamage(shellRigidbody.position);
        return damage;
    }
    private float CalculateDamage(Vector3 targetPosition)
    {
        float explosionRadius = shellController.getExplosionRadius();
        float damagePower = shellController.getDamagePower();
        
        Vector3 explosionToTarget = targetPosition - transform.position;
        float explosionDistance = explosionToTarget.magnitude;
        float relativeDistance = (explosionRadius - explosionDistance) / explosionRadius;
        float damage = relativeDistance * damagePower;
        
        damage = Mathf.Max(0f, damage);
        
        return damage;
    }
    
    private void SpawnDamageParticles()
    {
        Instantiate(shellExplosion, transform.position, Quaternion.identity);
    }

    public Rigidbody getShellRigidbody()
    {
        return shellRigidbody;
    }
}
