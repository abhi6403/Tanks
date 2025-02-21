using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public TankSpwaner tankSpwaner;
    public EnemySpawner enemySpawner;
    public GameObject lobbyPannel;
    public GameObject mainMenuPanel;
    public GameObject gameMenuUI;
    public GameObject gameOverPanel;
    
    public Button startButton;
    public Button quitButton;
    
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI TimeRemainingText;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI scoreText;

    private bool gameStarted = false;
    private float score = 0f;
    private float timeRemaining = 60f;
    private int timeLeft;

    private void Update()
    {
        if (gameStarted==true && timeRemaining > 0)
        {
            UpdateTimeRemainingText();
        }
        else if(timeRemaining <= 0)
        {
            GameOverMenu();
        }
    }

    public void StartButtonClicked()
    {
        lobbyPannel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void PlayagainButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitButtonClicked()
    {
        Application.Quit();
    }
    public void BlueTankSlelected()
    {
        tankSpwaner.CreateTank(TankTypes.BLUETANK);
        OpenGame();
    }
    
    public void GreenTankSlelected()
    {
        tankSpwaner.CreateTank(TankTypes.GREENTANK);
        OpenGame();
    }
    
    public void RedTankSlelected()
    {
        tankSpwaner.CreateTank(TankTypes.REDTANK);
        OpenGame();
    }

    public void OpenGame()
    {
        gameStarted = true;
        lobbyPannel.SetActive(false);
        gameMenuUI.SetActive(true);
        enemySpawner.createEnemy();
    }

    public void GameOverMenu()
    {
        gameStarted = false;
        gameOverPanel.SetActive(true);
        ShowResultText();
    }
    
    public void UpdateScoreText(float increment)
    {
        score += increment;
        ScoreText.text = "Score: " + score;
    }

    public void ShowResultText()
    {
        scoreText.text =  ""+score;
        resultText.text = "Mastered!!!";
    }
    public void UpdateTimeRemainingText()
    {
        timeRemaining -= Time.deltaTime;
        timeLeft = (int)timeRemaining;
        TimeRemainingText.text = "Time Left: " + timeLeft;
    }
    
}
