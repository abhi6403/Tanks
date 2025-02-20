using UnityEngine;
using UnityEngine.Accessibility;

public class TankModel 
{
    private TankController tankController;

    private float movementSpeed;
    private float rotationSpeed;
    private float damagePower;
    
    private TankTypes tankType;
    private Material tankMaterial;

    private float minLaunchForce = 15f;
    private float maxLaunchForce = 30f;
    private float maxChargeTime = 0.75f;

    private float currentLaunchForce;
    private float chargeSpeed;
    private bool fired;
    private ShellType shellType;

    public TankModel(float _movement, float _rotation,TankTypes _tankType, Material _tankMaterial,ShellType _shellType,float _damagePower)
    {
        movementSpeed = _movement;
        rotationSpeed = _rotation;
        tankType = _tankType;
        tankMaterial = _tankMaterial;
        shellType = _shellType;
        damagePower = _damagePower;
        
        currentLaunchForce = minLaunchForce; 

        chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
    }
    public void setTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
    
    public void setCurrentLaunchForce(float _currentLaunchForce)
    {
        currentLaunchForce = _currentLaunchForce;
    }

    public float getDamagePower()
    {
        return damagePower;
    }
    public TankTypes getTankType()
    {
        return tankType;
    }

    public float getMovementSpeed()
    {
        return movementSpeed;
    }

    public float getRotationSpeed()
    {
        return rotationSpeed;
    }

    public float getChargeSpeed()
    {
        return chargeSpeed;
    }
    public Material getTankMaterial()
    {
        return tankMaterial;
    }

    public float getMaxLaunchForce()
    {
        return maxLaunchForce;
    }

    public float getMinLaunchForce()
    {
        return minLaunchForce;
    }

    public float getMaxChargeTime()
    {
        return maxChargeTime;
    }

    public float getCurrentLaunchForce()
    {
        return currentLaunchForce;
    }
    public bool getFiredState()
    {
        return fired;
    }

    public void setFiredState(bool _fired)
    {
        fired = _fired;
    }
    
    
}
