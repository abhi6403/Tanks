using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using Object = UnityEngine.Object;

public class ShellController
{
    private ShellView shellView;
    private ShellModel shellModel;
    private Rigidbody shellRigidBody;

    public ShellController(ShellView _shellView, ShellModel _shellModel)
    {
        shellModel = _shellModel;
        shellModel.SetShellController(this);
        Transform originTransform = getOriginTransform();
        shellView = GameObject.Instantiate<ShellView>(_shellView);
        shellView.SetShellController(this);
        shellRigidBody = shellView.getShellRigidbody();
        shellRigidBody.velocity = getVelocity();
    }

    private ShellView Fire(ShellView shellView, Transform shellTransform)
    {
        GameObject shellGameObject = Object.Instantiate(shellView.gameObject, shellTransform.position, shellTransform.rotation);
        
        return shellGameObject.GetComponent<ShellView>();
    }

    public float getExplosionRadius()
    {
        return shellModel.getExplosionRadius();
    }

    public Transform getOriginTransform()
    {
        return shellModel.getOriginPoint();
    }

    public Vector3 getVelocity()
    {
        return shellModel.getVelocity();
    }
    public float getExplosionForce()
    {
        return shellModel.getExplosionForce();
    }

    public float getDamagePower()
    {
        return shellModel.getDamagePower();
    }
    
    
}
