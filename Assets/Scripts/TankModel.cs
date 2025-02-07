using UnityEngine;

public class TankModel 
{
    private TankController tankController;

    public float movementSpeed;
    public float rotationSpeed;

    public TankModel(float _movement, float _rotation)
    {
        movementSpeed = _movement;
        rotationSpeed = _rotation;
    }
    public void setTankController(TankController _tankController)
    {
        tankController = _tankController;
    }

    
}
