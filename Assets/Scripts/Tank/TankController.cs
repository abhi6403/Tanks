using UnityEngine;

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

        tankView.ChangeColor(tankModel.GetTankMaterial());
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
        tankView.getSlider().value = tankModel.getMinLaunchForce();

        if (tankModel.getCurrentLaunchForce() >= tankModel.getMaxLaunchForce() && !tankModel.getFiredState())
        {
            tankModel.setCurrentLaunchForce(tankModel.getMaxLaunchForce());
            tankView.Fire();
        }
        else if (Input.GetButtonDown("Jump"))
        {
            tankModel.setFiredState(false);
            tankModel.setCurrentLaunchForce( tankModel.getMinLaunchForce()); 
        }
        else if (Input.GetButton("Jump") && !tankModel.getFiredState())
        {
            float tempLaunchForce = tankModel.getCurrentLaunchForce() + tankModel.getChargeSpeed() * Time.deltaTime;
            tankModel.setCurrentLaunchForce(tempLaunchForce);
            tankView.getSlider().value = tankModel.getCurrentLaunchForce();
        }
        else if (Input.GetButtonUp("Jump"))
        {
            tankView.Fire();
        }
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
