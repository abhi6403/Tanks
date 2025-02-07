using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;

    public void setTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
