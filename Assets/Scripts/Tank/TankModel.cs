using UnityEngine;

public class TankModel 
{
    private TankController tankController;

    private float movementSpeed;
    private float rotationSpeed;
    private float damagePower;
    private float health;
    
    private TankTypes tankType;
    private Material tankMaterial;

    private float minLaunchForce = 15f;
    private float maxLaunchForce = 30f;
    private float maxChargeTime = 0.75f;

    private float currentLaunchForce;
    private float chargeSpeed;
    private bool fired;

    public TankModel(float _movement, float _rotation,TankTypes _tankType, Material _tankMaterial,float _damagePower,float _health)
    {
        movementSpeed = _movement;
        rotationSpeed = _rotation;
        tankType = _tankType;
        tankMaterial = _tankMaterial;
        damagePower = _damagePower;
        health = _health;
        
        currentLaunchForce = minLaunchForce; 

        chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
    }
    public void setTankController(TankController _tankController)
    {
        tankController = _tankController;
        
    }

    public void setHealth(float _health)
    {
        health -= _health;
    }
    public void setCurrentLaunchForce(float _currentLaunchForce)
    {
        currentLaunchForce = _currentLaunchForce;
    }

    public float GetHealth()
    {
        return health;
    }
    public float GetDamagePower()
    {
        return damagePower;
    }
    public float GetMovementSpeed()
    {
        return movementSpeed;
    }

    public float GetRotationSpeed()
    {
        return rotationSpeed;
    }

    public float GetChargeSpeed()
    {
        return chargeSpeed;
    }
    public Material GetTankMaterial()
    {
        return tankMaterial;
    }

    public float GetMaxLaunchForce()
    {
        return maxLaunchForce;
    }

    public float GetMinLaunchForce()
    {
        return minLaunchForce;
    }
    public float GetCurrentLaunchForce()
    {
        return currentLaunchForce;
    }
    public bool GetFiredState()
    {
        return fired;
    }
    public void SetFiredState(bool _fired)
    {
        fired = _fired;
    }
    
    
}
