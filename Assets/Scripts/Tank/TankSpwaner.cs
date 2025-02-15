using System.Collections.Generic;
using UnityEngine;

public class TankSpwaner : MonoBehaviour
{
    [System.Serializable]
    public class Tank
    {
        public float movementSpeed;
        public float rotationSpeed;
        public ShellType shellType;
        public TankTypes tankType;
        public Material color;
    }
    
    public TankView tankView;

    public List<Tank> tanksList;
 
    public void CreateTank(TankTypes tankType)
    {
        if (tankType == TankTypes.BLUETANK)
        {
            TankModel tankModel = new TankModel(tanksList[2].movementSpeed,tanksList[2].rotationSpeed,tanksList[2].tankType,tanksList[2].color,tanksList[2].shellType);
            TankController controller = new TankController(tankModel, tankView);
        }
       
        if (tankType == TankTypes.GREENTANK)
        {
            TankModel tankModel = new TankModel(tanksList[0].movementSpeed,tanksList[0].rotationSpeed,tanksList[0].tankType,tanksList[0].color,tanksList[0].shellType);
            TankController controller = new TankController(tankModel, tankView);
        }
        
        if (tankType == TankTypes.REDTANK)
        {
            TankModel tankModel = new TankModel(tanksList[1].movementSpeed,tanksList[1].rotationSpeed,tanksList[1].tankType,tanksList[1].color,tanksList[1].shellType);
            TankController controller = new TankController(tankModel, tankView);
        }
    }
}
