using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public TankSpwaner tankSpwaner;
    public GameObject lobbyPannel;
    public GameObject mainMenuPanel;
    public GameObject gameMenuUI;
    public Button startButton;
    public Button quitButton;

    public void StartButtonClicked()
    {
        lobbyPannel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void QuitButtonClicked()
    {
        Application.Quit();
    }
    public void BlueTankSlelected()
    {
        tankSpwaner.CreateTank(TankTypes.BLUETANK);
        OpenGameMenu();
    }
    
    public void GreenTankSlelected()
    {
        tankSpwaner.CreateTank(TankTypes.GREENTANK);
        OpenGameMenu();
    }
    
    public void RedTankSlelected()
    {
        tankSpwaner.CreateTank(TankTypes.REDTANK);
        OpenGameMenu();
    }

    public void OpenGameMenu()
    {
        lobbyPannel.SetActive(false);
        gameMenuUI.SetActive(true);
    }
    
    
}
