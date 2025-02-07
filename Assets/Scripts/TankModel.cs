using UnityEngine;

public class TankModel 
{
    private TankController tankController;

    public float movementSpeed;
    public float rotationSpeed;
    
    public TankTypes tankType;
    public Material tankMaterial;

    public TankModel(float _movement, float _rotation,TankTypes _tankType, Material _tankMaterial)
    {
        movementSpeed = _movement;
        rotationSpeed = _rotation;
        tankType = _tankType;
        tankMaterial = _tankMaterial;
    }
    public void setTankController(TankController _tankController)
    {
        tankController = _tankController;
    }

    /*public void setTankColor(Material color)
    {
        tankMaterial = color;
    }*/

    
}
