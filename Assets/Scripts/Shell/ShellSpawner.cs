using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellSpawner : MonoBehaviour
{

    [SerializeField] private ShellView shellView;

    public void SpawnShell(Vector3 position, Quaternion rotation,float launchForce, Vector3 forward,ShellParentType shellParentType)
    {

        ShellModel shellModel = new ShellModel(
            position,
            rotation,
            launchForce,
            forward,
            shellParentType);
           ShellController shellController = new ShellController(shellModel, shellView);
       
    }
}
