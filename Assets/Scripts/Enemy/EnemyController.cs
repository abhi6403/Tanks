using UnityEngine;
using UnityEngine.AI;

public class EnemyController
{
   private EnemyModel enemyModel;
   private EnemyView enemyView;
   private ShellSpawner shellSpawner;

   private Vector3 targetDirection;
   private NavMeshAgent navMeshAgent;
   
   private float launchForce;
   private float reloadTime;
   private float reloadTimer;
   
   public EnemyController(EnemyModel _enemyModel, EnemyView _enemyView)
   {
      enemyModel = _enemyModel;
      enemyView = GameObject.Instantiate(_enemyView);
      
      enemyModel.setEnemyController(this);
      enemyView.setEnemyController(this);
      
      enemyView.SetTankPosition(enemyModel.getSpawnPoint());
      enemyView.ChangeColor(enemyModel.getMaterial());
      navMeshAgent = enemyView.GetComponent<NavMeshAgent>();

   }

   public void Start()
   {
      shellSpawner = GameObject.FindObjectOfType<ShellSpawner>();
      reloadTime = 2f;
      reloadTimer = 0f;
      launchForce = 15f;
   }
   
   public void Update()
   {
      if (enemyView.isPlayerFound)
      {
         reloadTimer += Time.deltaTime;

         if (reloadTimer > reloadTime)
         {
            Fire();
         }
      }
   }

   private void Fire()
   {
         shellSpawner.SpawnShell(enemyView.GetFireTransform().position,enemyView.GetFireTransform().rotation,launchForce,enemyView.GetFireTransform().forward,ShellParentType.ENEMYTANK);

         reloadTimer = 0;
   }
   
   public void UpdateTargetDirection()
   {

      if (!enemyView.isPlayerFound)
      {
         navMeshAgent.isStopped = false;
         navMeshAgent.SetDestination(enemyView.GetTankView().transform.position);
      }
      else
      {
         navMeshAgent.isStopped = true;

         targetDirection = enemyView.DirectionToPlayer;
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
   
   public void TakeDamage(int damage)
   {
       enemyModel.setHealth(damage);
       enemyView.GetHealthSlider().value = enemyModel.getHealth();
   }
   public float GetHealth()
   {
      return enemyModel.getHealth();
   }
   
}
