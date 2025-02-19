using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private EnemyController enemyController;

    [SerializeField] private MeshRenderer[] childs;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private ShellSpawner shellSpawner;
    private float timer;
    private float waitTime = 5f;

    private void Start()
    {
        shellSpawner = GameObject.FindObjectOfType<ShellSpawner>();
    }

    private void Update()
    {
        if (Time.time > timer + waitTime)
        {
            Fire();
            timer = Time.time;
        }
    }

    public void setEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
    
    public void ChangeColor(Material color)
    {
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].material = color;
        }
    }
    
    public void Fire()
    {
        shellSpawner.SpawnShell(fireTransform.position,fireTransform.rotation,enemyController.getLaunchForce(),fireTransform.forward,ShellParentType.ENEMYTANK);
    }
    
    public void setTankPoisition(Transform poi)
    {
       gameObject.transform.position = poi.position;
    }
}
