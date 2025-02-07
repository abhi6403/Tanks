using UnityEngine;

public class TankController 
{
    private TankModel tankModel;
    private TankView tankView;

    public TankController(TankModel _tankModel, TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = _tankView;
        
        tankModel.setTankController(this);
        tankView.setTankController(this);
        
        GameObject.Instantiate(tankView.gameObject);
    }
}
