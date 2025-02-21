using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class TankController 
{
    private TankModel tankModel;
    private TankView tankView;
    
    private Rigidbody tankRigidbody;

    public TankController(TankModel _tankModel, TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankView);
        tankRigidbody = tankView.getRigidbody();
        
        tankModel.setTankController(this);
        tankView.setTankController(this);

        tankView.ChangeColor(tankModel.getTankMaterial());
    }

    public void Move(float movement,float movementSpeed)
    {
        tankRigidbody.velocity = tankView.transform.forward * movementSpeed * movement;
    }

    public void Rotate(float rotate, float rotationSpeed)
    {
        Vector3 vector = new Vector3(0f,rotate * rotationSpeed,0f);
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        tankRigidbody.MoveRotation(tankRigidbody.rotation * deltaRotation);
    }

    public void FireProcess()
    {
        getAimSlider().value = tankModel.getMinLaunchForce();

        if (getCurrentLaunchForce() >= getMaxLaunchForce() && !getFiredState())
        {
            setCurrentLaunchForce(getMaxLaunchForce());
            tankView.Fire();
        }
        else if (Input.GetButtonDown("Jump"))
        {
            setFiredState(false);
            setCurrentLaunchForce(getMinLaunchForce());
        }
        else if (Input.GetButton("Jump") && !getFiredState())
        {
            float temp = getCurrentLaunchForce() + getMaxChargeSpeed() * Time.deltaTime;
            setCurrentLaunchForce(temp);
            getAimSlider().value = getCurrentLaunchForce();
        }
        else if (Input.GetButtonUp("Jump"))
        {
            tankView.Fire();
        }
    }

    public void TakeDamage(int damage)
    {
        tankModel.setHealth(damage);
    }
    public void setCurrentLaunchForce(float newLaunchForce)
    {
        tankModel.setCurrentLaunchForce(newLaunchForce);
    }
    public TankTypes getTankType()
    {
        return tankModel.getTankType();
    }
    public float getMinLaunchForce()
    {
        return tankModel.getMinLaunchForce();
    }

    public float getHealth()
    {
        return tankModel.getHealth();
    }
    public Transform getTankTransform()
    {
        return tankView.getTankTransform();
    }
    public float getMaxLaunchForce()
    {
        return tankModel.getMaxLaunchForce();
    }

    public float getCurrentLaunchForce()
    {
        return tankModel.getCurrentLaunchForce();
    }

    public float getMaxChargeSpeed()
    {
        return tankModel.getChargeSpeed();
    }

    public float getMaxChargeTime()
    {
        return tankModel.getMaxChargeTime();
    }

    public bool getFiredState()
    {
       return tankModel.getFiredState();
    }

    public void setFiredState(bool state)
    {
        tankModel.setFiredState(state);
    }

    public float getMovementSpeed()
    {
        return tankModel.getMovementSpeed();
    }

    public float getDamagePower()
    {
        return tankModel.getDamagePower();
    }
    public float getRotationSpeed()
    {
        return tankModel.getRotationSpeed();
    }

    public Slider getAimSlider()
    {
        return tankView.getAimSlider();
    }
    public TankModel GetTankModel()
    {
        return tankModel;
    }

    public TankView GetTankView()
    {
        return tankView;
    }

    
}
