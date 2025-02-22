using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum GameState
{
    STARTMENU,
    GAMEPLAY,
    GAMEOVER,
}
public class GameManager : MonoBehaviour
{
    private GameState gameState;

    public void setGameState(GameState gameState)
    {
        this.gameState = gameState;
    }

    public GameState getGameState()
    {
        return gameState;
    }

}
