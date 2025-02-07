using System.Collections.Generic;
using UnityEngine;

public class TankSpwaner : MonoBehaviour
{
    [System.Serializable]
    public class Tank
    {
        public float movementSpeed;
        public float rotationSpeed;

        public TankTypes tankType;
        public Material color;
    }
    
    public TankView tankView;

    public List<Tank> tanksList;
    void Start()
    {
        CreateTank();
    }

    public void CreateTank()
    {
        TankModel tankModel = new TankModel(tanksList[1].movementSpeed,tanksList[1].rotationSpeed,tanksList[1].tankType,tanksList[1].color);
        TankController controller = new TankController(tankModel, tankView);
    }
}
