using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellView : MonoBehaviour
{
    [SerializeField]private ParticleSystem shellExploision;
    private ShellController shellController;

    private void OnCollisionEnter(Collision collision)
    {
        SpawnDamageParticles();
        Destroy(gameObject);
    }
    private void SpawnDamageParticles()
    {
        Instantiate(shellExploision, transform.position, Quaternion.identity);
    }
}
