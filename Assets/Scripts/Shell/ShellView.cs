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
   public Rigidbody GetRigidbody()
   {
       return shellRigidBody;
   }
    private void OnCollisionEnter()
    {
        SpawnDamageParticles();
        Explode();
    }

    public ShellParentType GetShellParentType()
    {
        return shellController.getShellParentType();
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
