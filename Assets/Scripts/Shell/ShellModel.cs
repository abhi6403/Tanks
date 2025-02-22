using UnityEngine;

public class ShellModel 
{
    private ShellController shellController;
    
    private Vector3 position;
    private Vector3 direction;
    private Quaternion rotation;
    private float launchForce;
    private ShellParentType shellParentType;
    
    public ShellModel(Vector3 _position, Quaternion _rotation,float _launchForce, Vector3 _forward, ShellParentType _shellParentType)
    {
        position = _position;
        rotation = _rotation;
        launchForce = _launchForce;
        direction = _forward;
        shellParentType = _shellParentType;
    }

    public void setShellController(ShellController _shellController)
    {
        shellController = _shellController;
    }

    public ShellParentType GetShellParentType()
    {
        return shellParentType;
    }
    public Vector3 GetPosition()
    {
        return position;
    }

    public Vector3 GetDirection()
    {
        return direction;
    }

    public Quaternion GetRotation()
    {
        return rotation;
    }

    public float GetLaunchForce()
    {
        return launchForce;
    }
}
