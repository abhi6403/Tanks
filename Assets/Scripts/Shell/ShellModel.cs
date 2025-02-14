using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellModel
{
   private ShellController shellController;
   
   private ShellTypes shellType;
   private float damagePower;
   private float explosionRadius;
   private float explosionForce;
   private Vector3 velocity;
   private Transform originPoint;

   public ShellModel(
      ShellTypes _shellType, 
      float _damage, 
      float _explosionRadius,
      float _explosionForce,
      Vector3 _velocity,
      Transform _originPoint)
   {
      shellType = _shellType;
      damagePower = _damage;
      explosionRadius = _explosionRadius;
      explosionForce = _explosionForce;
      velocity = _velocity;
      originPoint = _originPoint;
   }

   public void SetShellController(ShellController _shellController)
   {
      shellController = _shellController;
   }

   public float getExplosionRadius()
   {
      return explosionRadius;
   }

   public float getExplosionForce()
   {
      return explosionForce;
   }
   
   public float getDamagePower()
   {
      return damagePower;
   }

   public Vector3 getVelocity()
   {
      return velocity;
   }

   public Transform getOriginPoint()
   {
      return originPoint;
   }

}
