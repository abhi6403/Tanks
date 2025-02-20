using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController
{
   private EnemyModel enemyModel;
   private EnemyView enemyView;

   private Vector3 targetDirection;
   private NavMeshAgent navMeshAgent;
   
   private float launchForce;
   private float reloadTime;
   private float reloadTimer = 0;
   private ShellSpawner shellSpawner;
   public EnemyController(EnemyModel _enemyModel, EnemyView _enemyView)
   {
      enemyModel = _enemyModel;
      enemyView = GameObject.Instantiate<EnemyView>(_enemyView);
      
      enemyModel.setEnemyController(this);
      enemyView.setEnemyController(this);
      
      enemyView.setTankPoisition(enemyModel.getSpawnPoint());
      enemyView.ChangeColor(enemyModel.getMaterial());
      navMeshAgent = enemyView.GetComponent<NavMeshAgent>();

   }

   public void Start()
   {
      shellSpawner = GameObject.FindObjectOfType<ShellSpawner>();
      reloadTime = 2f;
      launchForce = 15f;
   }
   
   public void Update()
   {
      reloadTimer += Time.deltaTime;

      if (reloadTimer > reloadTime)
      {
         Fire();
      }
   }

   private void Fire()
   {
         shellSpawner.SpawnShell(enemyView.getFireTransform().position,enemyView.getFireTransform().rotation,launchForce,enemyView.getFireTransform().forward,ShellParentType.ENEMYTANK);

         reloadTimer = 0;
   }
   
   public void UpdateTargetDirection()
   {

      if (!enemyView.isPlayerFound)
      {
         navMeshAgent.isStopped = false;
         navMeshAgent.SetDestination(enemyView.getTankView().transform.position);
      }
      else
      {
         navMeshAgent.isStopped = true;

         targetDirection = enemyView.directionToPlayer;
         navMeshAgent.SetDestination(enemyView.transform.position);

      }
   }
   
   public void RotateTowardsTarget()
   {
      if (targetDirection == Vector3.zero)
      {
         return;
      }

      if (enemyView.isPlayerFound)
      {
            
         Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
         Quaternion rotation = Quaternion.RotateTowards(enemyView.transform.rotation, targetRotation, enemyModel.getRotationSpeed() * Time.deltaTime);
         enemyView.transform.rotation = rotation;
      }
   }
   public float getMoveSpeed()
   {
      return enemyModel.getMovementSpeed();
   }
   public EnemyType getEnemyType()
   {
      return enemyModel.getEnemyType();
   }
   public float getLaunchForce()
   {
      return enemyModel.getLaunchForce();
   }
}
