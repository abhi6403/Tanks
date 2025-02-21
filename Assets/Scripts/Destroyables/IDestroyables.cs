using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDestroyables 
{
    public float getDamagePower();
    public void processDamage();

    public void spawnDamageParticles();
    
    public void TakeDamage(float damage);
}
