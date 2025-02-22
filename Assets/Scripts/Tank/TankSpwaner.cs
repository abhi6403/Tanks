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
        public float health;
        public TankTypes tankType;
        public Material color;
    }
    
    [SerializeField] private TankView tankView;

    [SerializeField] private List<Tank> tanksList;
 
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
            TankModel tankModel = new TankModel(tank.movementSpeed,tank.rotationSpeed,tank.tankType,tank.color,tank.damagePower,tank.health);
            TankController controller = new TankController(tankModel, tankView);
        }
    }
}
