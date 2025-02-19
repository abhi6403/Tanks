using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    private EnemyController enemyController;
    
    private float movementSpeed;
    private float rotationSpeed;
    private float damagePower;
    private Material material;

    private float launchForce = 15;

    public EnemyModel(float _movementSpeed, float _rotationSpeed, float _damagePower, Material _material)
    {
        movementSpeed = _movementSpeed;
        rotationSpeed = _rotationSpeed;
        damagePower = _damagePower;
        material = _material;
    }

    public void setEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }

    public float getLaunchForce()
    {
        return launchForce;
    }
    public float getMovementSpeed()
    {
        return movementSpeed;
    }

    public float getRotationSpeed()
    {
        return rotationSpeed;
    }

    public float getDamagePower()
    {
        return damagePower;
    }

    public Material getMaterial()
    {
        return material;
    }
}
