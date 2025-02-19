using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemyTank
    {
        public float movementSpeed;
        public float rotationSpeed;
        public float damagePower;
        public Material color;
        public Transform spawnPoint;
    }

    public EnemyView enemyView;
    
    [SerializeField] private List<EnemyTank> enemyList;
    
    public void createEnemy()
    {
        for (int i = 0; i <= enemyList.Count; i++)
        {
            EnemyModel enemyModel =
                new EnemyModel(enemyList[i].movementSpeed, enemyList[i].rotationSpeed, enemyList[i].damagePower, enemyList[i].color,enemyList[i].spawnPoint);
            EnemyController enemyController = new EnemyController(enemyModel, enemyView);
        }
    }
}
