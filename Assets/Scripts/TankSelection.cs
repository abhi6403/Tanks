using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSelection : MonoBehaviour
{
    public TankSpwaner tankSpwaner;
    
    public void BlueTankSlelected()
    {
        tankSpwaner.CreateTank(TankTypes.BLUETANK);
        this.gameObject.SetActive(false);
    }
    
    public void GreenTankSlelected()
    {
        tankSpwaner.CreateTank(TankTypes.GREENTANK);
        this.gameObject.SetActive(false);
    }
    
    public void RedTankSlelected()
    {
        tankSpwaner.CreateTank(TankTypes.REDTANK);
        this.gameObject.SetActive(false);
    }
}
