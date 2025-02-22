using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectsToBeDestroyed : MonoBehaviour
{
    [SerializeField] private List<Destroyables> destroyableObjects;
    private GameObject objectToDestroy;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        CheckForDestroyableObjects();
    }

    public void CheckForDestroyableObjects()
    {
        if (destroyableObjects.Count == 0)
        {
            UIController uiController = FindObjectOfType<UIController>();
            gameManager.setGameState(GameState.GAMEOVER);
            
        }
    }

    public void AssignDestroyableObjects(Destroyables destroyables)
    {
        destroyableObjects.Add(destroyables);
    }

    public void RemoveDestroyableObjects(Destroyables destroyables)
    {
        destroyableObjects.Remove(destroyables);
    }
}
