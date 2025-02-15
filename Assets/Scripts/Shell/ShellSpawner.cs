using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellSpawner : MonoBehaviour
{

    [SerializeField] private ShellView shellView;
    [System.Serializable]
    public class Shell
    {
        public ShellType shellType;
        public float damagePower;
    }
    
    [SerializeField] private List<Shell> shellList;

    public void SpawnShell(Vector3 position, Quaternion rotation,float launchForce, Vector3 forward,ShellType shellType)
    {
       Shell shell = null;
       switch (shellType)
       {
           case ShellType.REDTANKSHELL:
               shell = shellList[0];
               break;
           case ShellType.BLUETANKSHELL:
               shell = shellList[1];
               break;
           case ShellType.GREENTANKSHELL:
               shell = shellList[2];
               break;
       }

       if (shell != null)
       {
           ShellModel shellModel = new ShellModel(
               position,
               rotation,
               launchForce,
               forward,
               shell.shellType,
               shell.damagePower);
           ShellController shellController = new ShellController(shellModel, shellView);
       }
    }
    
}
