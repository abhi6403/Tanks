using UnityEngine;

public class TankSpwaner : MonoBehaviour
{
    public TankView tankView;

    void Start()
    {
        CreateTank();
    }

    public void CreateTank()
    {
        TankModel tankModel = new TankModel();
        TankController controller = new TankController(tankModel, tankView);
    }
}
