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
    [SerializeField] private Slider healthSlider;

    [SerializeField] private Rigidbody shell;
    [SerializeField] private ShellSpawner shellSpawner;
    public void setTankController(TankController _tankController)
    {
        tankController = _tankController;
    }

    private void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        cameraShake = cam.GetComponent<CameraShake>();
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 4f, -10f);
        aimSlider.value = tankController.getMinLaunchForce();
        healthSlider.value = tankController.getHealth();
        shellSpawner = GameObject.FindObjectOfType<ShellSpawner>();
    }

    private void Update()
    {
        Movement();
        MoveTank();
        tankController.FireProcess();
    }

    private void MoveTank()
    {
        if (movement != 0)
        {
            tankController.Move(movement,tankController.getMovementSpeed());
        }

        if (rotation != 0)
        {
            tankController.Rotate(rotation,tankController.getRotationSpeed());
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
        tankController.setFiredState(true);
        StartCoroutine(cameraShake.Shake(0.1f, 0.1f)); 
        shellSpawner.SpawnShell(fireTransform.position,fireTransform.rotation,tankController.getCurrentLaunchForce(),fireTransform.forward,ShellParentType.PLAYERTANK);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (tankController.getHealth() >= 0)
        {
            if (other.gameObject.GetComponent<ShellView>().getShellParentType() == ShellParentType.ENEMYTANK)
            {
                tankController.TakeDamage(5);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Transform getTankTransform()
    {
        return gameObject.transform;
    }

    public float getDamagePower()
    {
        return tankController.getDamagePower();
    }
    public TankTypes getTankType()
    {
        return tankController.getTankType();
    }
    public Slider getAimSlider()
    {
        return aimSlider;
    }

    public Slider getHealthSlider()
    {
        return healthSlider;
    }
    public Rigidbody getRigidbody()
    {
        return rb;
    }
}
