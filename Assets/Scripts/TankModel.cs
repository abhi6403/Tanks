using UnityEngine;

public class TankModel 
{
    private TankController tankController;

    public float movementSpeed;
    public float rotationSpeed;
    
    public TankTypes tankType;
    public Material tankMaterial;

    public float minLaunchForce = 15f;
    public float maxLaunchForce = 30f;
    public float maxChargeTime = 0.75f;

    public float currentLaunchForce;
    public float chargeSpeed;
    public bool fired;

    public TankModel(float _movement, float _rotation,TankTypes _tankType, Material _tankMaterial)
    {
        movementSpeed = _movement;
        rotationSpeed = _rotation;
        tankType = _tankType;
        tankMaterial = _tankMaterial;

        currentLaunchForce = minLaunchForce; 

        chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
    }
    public void setTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
