using System;
using UnityEngine;
using UnityEngine.UI;
using static ShellSpawner;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    private CameraShake cameraShake;
    private float movement;
    private float rotation;
    
    [SerializeField] private Rigidbody rb;
    [SerializeField] private MeshRenderer[] childs;

    [SerializeField] private Transform fireTransform;
    [SerializeField] private Slider aimSlider;

    [SerializeField] private Rigidbody shell;
    [SerializeField] private ShellSpawner shellSpawner;

    private void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        cameraShake = cam.GetComponent<CameraShake>();
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 3f, -4f);
        tankController.GetTankView().aimSlider.value = tankController.GetTankModel().getMinLaunchForce();
    }

    private void Update()
    {
        Movement();
        ControlMovement();
        tankController.FireProcess();
    }

    private void ControlMovement()
    {
        if (movement != 0)
        {
            tankController.Move(movement,tankController.GetTankModel().getMovementSpeed());
        }

        if (rotation != 0)
        {
            tankController.Rotate(rotation,tankController.GetTankModel().getRotationSpeed());
        }
    }

    private void Movement()
    {
        movement = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");
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
        Debug.Log("Shell Spawned");
        tankController.GetTankModel().setFiredState(true);
        StartCoroutine(cameraShake.Shake(0.1f, 0.1f));
        //Rigidbody shellInstance = Instantiate(shell, fireTransform.position, fireTransform.rotation) as Rigidbody;
        Vector3 velocity = tankController.GetTankModel().getCurrentLaunchForce() * fireTransform.transform.forward;
        shellSpawner.SpawnShell(ShellTypes.REDTANKSHELL,velocity,shellSpawner.transform);
    }

    public void setShellSpawner(ShellSpawner spawner)
    {
        
        shellSpawner = spawner;
    }
    
    public Rigidbody getRigidbody()
    {
        return rb;
    }

    public Slider getSlider()
    {
        return aimSlider;
    }
    
    public void setTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
