using System;
using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    private CameraShake cameraShake;
    private float movement;
    private float rotation;
    
    public Rigidbody rb;
    public MeshRenderer[] childs;

    public Transform fireTransform;
    public Slider aimSlider;

    public Rigidbody shell;
    public void setTankController(TankController _tankController)
    {
        tankController = _tankController;
    }

    private void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        cameraShake = cam.GetComponent<CameraShake>();
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 3f, -4f);
        tankController.GetTankView().aimSlider.value = tankController.GetTankModel().minLaunchForce;
    }

    private void Update()
    {
        Movement();

        if (movement != 0)
        {
            tankController.Move(movement,tankController.GetTankModel().movementSpeed);
        }

        if (rotation != 0)
        {
            tankController.Rotate(rotation,tankController.GetTankModel().rotationSpeed);
        }
        
        tankController.FireProcess();
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
        tankController.GetTankModel().fired = true;
        
        Rigidbody shellInstance = Instantiate(shell, fireTransform.position, fireTransform.rotation) as Rigidbody;
        StartCoroutine(cameraShake.Shake(0.1f, 0.1f));
        shellInstance.velocity = tankController.GetTankModel().currentLaunchForce * fireTransform.forward;
    }

    public Rigidbody getRigidbody()
    {
        return rb;
    }
}
