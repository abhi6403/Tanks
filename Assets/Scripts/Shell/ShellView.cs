using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellView : MonoBehaviour
{
    private ShellController shellController;
    
   [SerializeField] private ParticleSystem explosionParticle;
   [SerializeField] private Rigidbody shellRigidBody;
   
   public void setShellController(ShellController _shellController)
   {
       shellController = _shellController;
   }
   public Rigidbody getRigidbody()
   {
       return shellRigidBody;
   }
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
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
    }
}
