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
        public float health;
        public Material color;
        public Transform spawnPoint;
        public EnemyType type;
    }

    public EnemyView enemyView;
    
    [SerializeField] private List<EnemyTank> enemyList;
    
    public void createEnemy()
    {
        for (int i = 0; i <= enemyList.Count; i++)
        {
            EnemyModel enemyModel =
                new EnemyModel(enemyList[i].movementSpeed, enemyList[i].rotationSpeed, enemyList[i].damagePower, enemyList[i].color,enemyList[i].spawnPoint,enemyList[i].type,enemyList[i].health);
            EnemyController enemyController = new EnemyController(enemyModel, enemyView);
        }
    }
}
