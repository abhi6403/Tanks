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
    [SerializeField] private TankSpwaner tankSpwaner;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private GameObject lobbyPannel;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gameMenuUI;
    [SerializeField] private GameObject gameOverPanel;
    
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI TimeRemainingText;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private bool gameStarted;
    private float score;
    private float timeRemaining;
    private int timeLeft;

    private void Start()
    {
        gameStarted = false;
        score = 0f;
        timeRemaining = 60f;
    }

    private void Update()
    {
        if (!gameStarted && timeRemaining > 0)
        {
            UpdateTimeRemainingText();
        }
        else if(timeRemaining <= 0)
        {
            GameOverMenu();
        }
    }

    private void StartButtonClicked()
    {
        lobbyPannel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    private void PlayagainButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    private void QuitButtonClicked()
    {
        Application.Quit();
    }
    private void BlueTankSlelected()
    {
        tankSpwaner.CreateTank(TankTypes.BLUETANK);
        OpenGame();
    }
    
    private void GreenTankSlelected()
    {
        tankSpwaner.CreateTank(TankTypes.GREENTANK);
        OpenGame();
    }
    
    private void RedTankSlelected()
    {
        tankSpwaner.CreateTank(TankTypes.REDTANK);
        OpenGame();
    }

    private void OpenGame()
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

    private void ShowResultText()
    {
        scoreText.text =  ""+score;
        resultText.text = "Mastered!!!";
    }
    private void UpdateTimeRemainingText()
    {
        timeRemaining -= Time.deltaTime;
        timeLeft = (int)timeRemaining;
        TimeRemainingText.text = "Time Left: " + timeLeft;
    }
    
}
