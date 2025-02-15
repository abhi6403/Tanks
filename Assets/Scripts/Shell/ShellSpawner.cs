using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellSpawner : MonoBehaviour
{

    [SerializeField] private ShellView shellView;
    /*[System.Serializable]
    public class Shell
    {
        public Rigidbody rigidbody;
    }*/
    
    //public List<Shell> shells;

    public void SpawnShell(Vector3 position, Quaternion rotation,float launchForce, Vector3 forward)
    {
       ShellModel shellModel = new ShellModel(position, rotation, launchForce, forward);
       ShellController shellController = new ShellController(shellModel, shellView);
    }

    public void shootShell(Rigidbody rigidbody)
    {
        
    }
}
