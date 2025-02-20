using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
   public NavMeshAgent agent;
   public TankView tankView;
   public EnemyView enemyView;

   private Rigidbody rb;
   private Vector3 targetDirection;
   [SerializeField] private float targetDistance = 10f;
   public Vector3 directionToPlayer { get; private set; }
   public bool isPlayerFound { get; private set; }
   void Start()
   {
      agent = GetComponent<NavMeshAgent>();
      tankView = GameObject.FindObjectOfType<TankView>();
      enemyView = GameObject.FindObjectOfType<EnemyView>();
      rb = GetComponent<Rigidbody>();
   }
   void Update()
   {
             CheckForPlayer();
         if (isPlayerFound == false)
         {
             move();
         }
         
   }

   private void CheckForPlayer()
   {
       Vector3 enemyToPlayer = tankView.transform.position - transform.position;
       directionToPlayer = enemyToPlayer.normalized;
       float distanceToPlayer = enemyToPlayer.magnitude;

       if (distanceToPlayer <= targetDistance)
       {
           isPlayerFound = true;
       }
       else if(distanceToPlayer >= targetDistance)
       {
           isPlayerFound = false;
       }
   }

   private void move()
   {
       agent.destination = (tankView.transform.position - new Vector3(15f, 0f, 0f));
       
       if (!isPlayerFound)
       {
           agent.isStopped = false;
           agent.SetDestination(tankView.transform.position);
       }
       else
       {
           agent.isStopped = true;

           targetDirection = directionToPlayer;
           agent.SetDestination(enemyView.transform.position);

       }
   }
}
