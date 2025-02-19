using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController 
{
    private ShellView shellView; 
    private ShellModel shellModel;

    private Rigidbody shellRigidBody;

    public ShellController(ShellModel _shellModel, ShellView _shellView)
    {
        shellModel = _shellModel;
        shellView = GameObject.Instantiate<ShellView>(_shellView, getPosition(), getRotation());
        
        shellModel.setShellController(this);
        shellView.setShellController(this);
        
        SpawnShell();
        
    }

    private void SpawnShell()
    {
        shellRigidBody = shellView.getRigidbody();
        shellRigidBody.velocity = getLaunchForce() * getDirection();
    }

    public ShellParentType getShellParentType()
    {
        return shellModel.getShellParentType();
    }
    public Vector3 getPosition()
    {
        return shellModel.getPosition();
    }

    public Vector3 getDirection()
    {
        return shellModel.getDirection();
    }

    public Quaternion getRotation()
    {
        return shellModel.getRotation();
    }

    public float getLaunchForce()
    {
        return shellModel.getLaunchForce();
    }
    
}
