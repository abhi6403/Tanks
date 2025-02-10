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

        tankView.ChangeColor(tankModel.tankMaterial);
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
        tankView.aimSlider.value = tankModel.minLaunchForce;

        if (tankModel.currentLaunchForce >= tankModel.maxLaunchForce && !tankModel.fired)
        {
            tankModel.currentLaunchForce = tankModel.maxLaunchForce;
            tankView.Fire();
        }
        else if (Input.GetButtonDown("Jump"))
        {
            tankModel.fired = false;
            tankModel.currentLaunchForce = tankModel.minLaunchForce;
        }
        else if (Input.GetButton("Jump") && !tankModel.fired)
        {
            tankModel.currentLaunchForce += tankModel.chargeSpeed * Time.deltaTime;
            tankView.aimSlider.value = tankModel.currentLaunchForce;
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
