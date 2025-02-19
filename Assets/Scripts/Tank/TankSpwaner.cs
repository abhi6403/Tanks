using System.Collections.Generic;
using UnityEngine;

public class TankSpwaner : MonoBehaviour
{
    [System.Serializable]
    public class Tank
    {
        public float movementSpeed;
        public float rotationSpeed;
        public float damagePower;
        public ShellType shellType;
        public TankTypes tankType;
        public Material color;
    }
    
    public TankView tankView;

    public List<Tank> tanksList;
 
    public void CreateTank(TankTypes tankType)
    {
        Tank tank = null;
        switch (tankType)
        {
            case TankTypes.REDTANK:
                tank = tanksList[1];
                break;
            case TankTypes.BLUETANK:
                tank = tanksList[2];
                break;
            case TankTypes.GREENTANK:
                tank = tanksList[0];
                break;
        }

        if (tank != null)
        {
            TankModel tankModel = new TankModel(tank.movementSpeed,tank.rotationSpeed,tank.tankType,tank.color,tank.shellType,tank.damagePower);
            TankController controller = new TankController(tankModel, tankView);
        }
    }
}
