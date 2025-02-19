using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController
{
   private EnemyModel enemyModel;
   private EnemyView enemyView;

   public EnemyController(EnemyModel _enemyModel, EnemyView _enemyView)
   {
      enemyModel = _enemyModel;
      enemyView = GameObject.Instantiate<EnemyView>(_enemyView);
      
      enemyModel.setEnemyController(this);
      enemyView.setEnemyController(this);
      
      enemyView.setTankPoisition(enemyModel.getSpawnPoint());
      enemyView.ChangeColor(enemyModel.getMaterial());
      
   }
   
   public float getLaunchForce()
   {
      return enemyModel.getLaunchForce();
   }
}
