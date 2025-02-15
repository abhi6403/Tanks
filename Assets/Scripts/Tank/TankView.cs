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

    [SerializeField] private Rigidbody shell;
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
        aimSlider.value = tankController.getMinLaunchForce();
    }

    private void Update()
    {
        Movement();

        if (movement != 0)
        {
            tankController.Move(movement,tankController.getMovementSpeed());
        }

        if (rotation != 0)
        {
            tankController.Rotate(rotation,tankController.getRotationSpeed());
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
        tankController.setFiredState(true);
        
        Rigidbody shellInstance = Instantiate(shell, fireTransform.position, fireTransform.rotation) as Rigidbody;
        StartCoroutine(cameraShake.Shake(0.1f, 0.1f));
        shellInstance.velocity = tankController.getCurrentLaunchForce() * fireTransform.forward;
    }

    public Slider getAimSlider()
    {
        return aimSlider;
    }
    public Rigidbody getRigidbody()
    {
        return rb;
    }
}
