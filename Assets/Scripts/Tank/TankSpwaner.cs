using System.Collections.Generic;
using UnityEngine;

public class TankSpwaner : MonoBehaviour
{
    [System.Serializable]
    public class Tank
    {
        public float movementSpeed;
        public float rotationSpeed;
        public float minLaunchForce;
        public float maxLaunchForce;

        public TankTypes tankType;
        public Material color;
    }

    [SerializeField] private ShellSpawner shellSpawner;
    
    public TankView tankView;

    public List<Tank> tanksList;
 
    public void CreateTank(TankTypes tankType)
    {
        Tank tank = null;

        switch (tankType)
        {
            case TankTypes.GREENTANK:
                tank = tanksList[0];
                break;
            case TankTypes.BLUETANK:
                tank = tanksList[1];
                break;
            case TankTypes.REDTANK:
                tank = tanksList[2];
                break;
        }

        if (tank != null)
        {
            TankModel tankModel = new TankModel(
                tank.tankType,
                tank.color,
                tank.movementSpeed,
                tank.rotationSpeed,
                tank.minLaunchForce,
                tank.maxLaunchForce
            );
            
            TankController tankController = new TankController(tankModel,tankView);
        }
    }

    public ShellSpawner getShellSpawner()
    {
        return shellSpawner;
    }
}
