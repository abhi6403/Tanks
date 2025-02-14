using UnityEngine;

public class TankModel 
{
    private TankController tankController;

    private float movementSpeed;
    private float rotationSpeed;
    
    private TankTypes tankType;
    private Material tankMaterial;

    private float minLaunchForce;
    private float maxLaunchForce;
    private float maxChargeTime;

    private float currentLaunchForce;
    private float chargeSpeed;
    private bool fired;

    public TankModel(
        TankTypes _tankType,
        Material _tankMaterial,
        float _movement,
        float _rotation,
        float _minLaunchForce,
        float _maxLaunchForce
        )
    {
        movementSpeed = _movement;
        rotationSpeed = _rotation;
        tankType = _tankType;
        tankMaterial = _tankMaterial;
        minLaunchForce = _minLaunchForce;
        maxLaunchForce = _maxLaunchForce;

        currentLaunchForce = minLaunchForce; 

        chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
    }

    public TankTypes getTankType()
    {
        return tankType;
    }
    public Material GetTankMaterial()
    {
        return tankMaterial;
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

    public void setFiredState(bool _fired)
    {
        this.fired = _fired;
    }

    public bool getFiredState()
    {
        return fired;
    }
    public float getCurrentLaunchForce()
    {
        return currentLaunchForce;
    }

    public void setCurrentLaunchForce(float _currentLaunchForce)
    {
        currentLaunchForce = _currentLaunchForce;
    }
    public float getMinLaunchForce()
    {
        return minLaunchForce;
    }

    public float getMaxLaunchForce()
    {
        return maxLaunchForce;
    }
    public void setTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
