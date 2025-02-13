using System;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] public Rigidbody shell;
   

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
        tankController.GetTankModel().setFiredState(true);
        
        Rigidbody shellInstance = Instantiate(shell, fireTransform.position, fireTransform.rotation) as Rigidbody;
        StartCoroutine(cameraShake.Shake(0.1f, 0.1f));
        shellInstance.velocity = tankController.GetTankModel().getCurrentLaunchForce() * fireTransform.forward;
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
