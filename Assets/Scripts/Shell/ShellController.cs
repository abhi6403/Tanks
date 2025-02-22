using UnityEngine;

public class ShellController 
{
    private ShellView shellView; 
    private ShellModel shellModel;

    private Rigidbody shellRigidBody;

    public ShellController(ShellModel _shellModel, ShellView _shellView)
    {
        shellModel = _shellModel;
        shellView = GameObject.Instantiate(_shellView, getPosition(), getRotation());
        
        shellModel.setShellController(this);
        shellView.setShellController(this);
        
        SpawnShell();
        
    }

    private void SpawnShell()
    {
        shellRigidBody = shellView.GetRigidbody();
        shellRigidBody.velocity = GetLaunchForce() * getDirection();
    }

    public ShellParentType getShellParentType()
    {
        return shellModel.GetShellParentType();
    }
    public Vector3 getPosition()
    {
        return shellModel.GetPosition();
    }

    public Vector3 getDirection()
    {
        return shellModel.GetDirection();
    }

    public Quaternion getRotation()
    {
        return shellModel.GetRotation();
    }

    public float GetLaunchForce()
    {
        return shellModel.GetLaunchForce();
    }
    
}
