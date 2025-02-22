using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class TankController 
{
    private TankModel tankModel;
    private TankView tankView;
    
    private Rigidbody tankRigidbody;

    public TankController(TankModel _tankModel, TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate(_tankView);
        tankRigidbody = tankView.GetRigidbody();
        
        tankModel.setTankController(this);
        tankView.SetTankController(this);

        tankView.ChangeColor(tankModel.GetTankMaterial());
    }

    public void Move(float movement,float movementSpeed)
    {
        tankRigidbody.velocity = tankView.GetTankTransform() * movementSpeed * movement;
    }

    public void Rotate(float rotate, float rotationSpeed)
    {
        Vector3 vector = new Vector3(0f,rotate * rotationSpeed,0f);
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        tankRigidbody.MoveRotation(tankRigidbody.rotation * deltaRotation);
    }

    public void FireProcess()
    {
        getAimSlider().value = tankModel.GetMinLaunchForce();

        if (GetCurrentLaunchForce() >= getMaxLaunchForce() && !getFiredState())
        {
            setCurrentLaunchForce(getMaxLaunchForce());
            tankView.Fire();
        }
        else if (Input.GetButtonDown("Jump"))
        {
            SetFiredState(false);
            setCurrentLaunchForce(GetMinLaunchForce());
        }
        else if (Input.GetButton("Jump") && !getFiredState())
        {
            float temp = GetCurrentLaunchForce() + getMaxChargeSpeed() * Time.deltaTime;
            setCurrentLaunchForce(temp);
            getAimSlider().value = GetCurrentLaunchForce();
        }
        else if (Input.GetButtonUp("Jump"))
        {
            tankView.Fire();
        }
    }
    
    private void setCurrentLaunchForce(float newLaunchForce)
    {
        tankModel.setCurrentLaunchForce(newLaunchForce);
    }

    public void TakeDamage(int damage)
    {
        tankModel.setHealth(damage);
        tankView.GetHealthSlider().value = tankModel.GetHealth();
    }
    
    private float getMaxLaunchForce()
    {
        return tankModel.GetMaxLaunchForce();
    }
    
    private float getMaxChargeSpeed()
    {
        return tankModel.GetChargeSpeed();
    }
    
    private bool getFiredState()
    {
        return tankModel.GetFiredState();
    }
    
    private Slider getAimSlider()
    {
        return tankView.GetAimSlider();
    }
    
    public float GetMinLaunchForce()
    {
        return tankModel.GetMinLaunchForce();
    }

    public float GetHealth()
    {
        return tankModel.GetHealth();
    }

    public float GetCurrentLaunchForce()
    {
        return tankModel.GetCurrentLaunchForce();
    }
    public void SetFiredState(bool state)
    {
        tankModel.SetFiredState(state);
    }

    public float GetMovementSpeed()
    {
        return tankModel.GetMovementSpeed();
    }

    public float GetDamagePower()
    {
        return tankModel.GetDamagePower();
    }
    public float GetRotationSpeed()
    {
        return tankModel.GetRotationSpeed();
    }
}
