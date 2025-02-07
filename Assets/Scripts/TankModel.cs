using UnityEngine;

public class TankModel : MonoBehaviour
{
    private TankController tankController;

    public void setTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
