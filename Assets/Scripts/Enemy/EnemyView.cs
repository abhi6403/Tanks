using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{
    private EnemyController enemyController;
    public Vector3 directionToPlayer { get; private set; }
    public bool isPlayerFound { get; private set; }

    [SerializeField] private MeshRenderer[] childs;
    [SerializeField] private ParticleSystem particleExplosion;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private Slider healthSlider;
    
    [SerializeField] private float targetDistance;
    
    private Rigidbody rb;
    private Vector3 targetDirection;
    private float timer;
    private float waitTime = 5f;
    private TankView tankView;

    private void Start()
    {
        enemyController.Start();
        tankView = GameObject.FindObjectOfType<TankView>();
        healthSlider.value = enemyController.getHealth();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckForPlayer();
        enemyController.Update();
    }
    private void CheckForPlayer()
    {
        Vector3 enemyToPlayerVector = tankView.transform.position - transform.position;
        directionToPlayer = enemyToPlayerVector.normalized;
        float distanceToPlayer = enemyToPlayerVector.magnitude;

        float buffer = .2f;

        if (distanceToPlayer <= targetDistance - buffer)
        {

            isPlayerFound = true;
        }
        else if (distanceToPlayer >= targetDistance + buffer)
        {

            isPlayerFound = false;
        }
    }
    
    private void FixedUpdate()
    {
        if (enemyController != null)
        {
            enemyController.UpdateTargetDirection();
            enemyController.RotateTowardsTarget();
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (enemyController.getHealth() >= 0)
        {
            if (other.gameObject.GetComponent<ShellView>().getShellParentType() == ShellParentType.PLAYERTANK)
            {
                enemyController.TakeDamage(10);
            }
        }
        else
        {
            spawnDamageParticles();
            Destroy(gameObject);
        }
    }
    public void setEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
    
    public void spawnDamageParticles()
    {
        Instantiate(particleExplosion, transform.position, Quaternion.identity);
    }
    public void ChangeColor(Material color)
    {
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].material = color;
        }
    }

    public TankView getTankView()
    {
        return tankView;
    }
    
    public Rigidbody GetRigidBody()
    {
        return rb;
    }

    public Slider getHealthSlider()
    {
        return healthSlider;
    }
    public void setTankPoisition(Transform poi)
    {
       gameObject.transform.position = poi.position;
    }

    public Transform getFireTransform()
    {
        return fireTransform;
    }
}
