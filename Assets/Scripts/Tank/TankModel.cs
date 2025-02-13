using UnityEngine;

public class TankModel 
{
    private TankController tankController;

    private float movementSpeed;
    private float rotationSpeed;
    
    private TankTypes tankType;
    private Material tankMaterial;

    private float minLaunchForce = 15f;
    private float maxLaunchForce = 30f;
    private float maxChargeTime = 0.75f;

    private float currentLaunchForce;
    private float chargeSpeed;
    private bool fired;

    public TankModel(float _movement, float _rotation,TankTypes _tankType, Material _tankMaterial)
    {
        movementSpeed = _movement;
        rotationSpeed = _rotation;
        tankType = _tankType;
        tankMaterial = _tankMaterial;

        currentLaunchForce = minLaunchForce; 

        chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
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
