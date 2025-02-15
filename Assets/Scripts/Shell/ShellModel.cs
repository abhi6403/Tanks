using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellModel 
{
    private ShellController shellController;
    
    private Vector3 position;
    private Vector3 direction;
    private Quaternion rotation;
    private float launchForce;
    private ShellType shellType;
    private float damagePower;
    
    public ShellModel(Vector3 _position, Quaternion _rotation,float _launchForce, Vector3 _forward,ShellType _shellType,float _damagePower)
    {
        position = _position;
        rotation = _rotation;
        launchForce = _launchForce;
        direction = _forward;
        shellType = _shellType;
        damagePower = _damagePower;
    }

    public void setShellController(ShellController _shellController)
    {
        shellController = _shellController;
    }

    public float getDamagePower()
    {
        return damagePower;
    }
    public Vector3 getPosition()
    {
        return position;
    }

    public Vector3 getDirection()
    {
        return direction;
    }

    public Quaternion getRotation()
    {
        return rotation;
    }

    public float getLaunchForce()
    {
        return launchForce;
    }
}
