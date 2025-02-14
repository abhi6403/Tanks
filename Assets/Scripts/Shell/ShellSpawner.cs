using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellSpawner : MonoBehaviour
{
    [SerializeField] private ShellView shellView;

    [System.Serializable]
    public class Shell
    {
        public ShellTypes shellType;
        public float damagePower;
        public float explosionRadius;
        public float explosionForce;
    }

    [SerializeField] private List<Shell> shells;
    
    
    public void SpawnShell(ShellTypes shellType,Vector3 velocity,Transform originPoint)
    {
        Shell shell = null;

        switch (shellType)
        {
            case ShellTypes.REDTANKSHELL:
                shell = shells[2];
                break;
            case ShellTypes.BLUETANKSHELL:
                shell = shells[1];
                break;
            case ShellTypes.GREENTANKSHELL:
                shell = shells[0];
                break;
        }

        if (shell != null)
        {
            ShellModel shellModel = new ShellModel(
                shell.shellType, 
                shell.damagePower, 
                shell.explosionRadius,
                shell.explosionForce,
                velocity,
                originPoint
                );
            
            ShellController shellController = new ShellController(shellView,shellModel);
           
        }
            
    }
}
