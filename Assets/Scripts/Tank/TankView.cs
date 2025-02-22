using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    private UIController uiController;
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
    
    

    private void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        cameraShake = cam.GetComponent<CameraShake>();
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 4f, -10f);
        aimSlider.value = tankController.GetMinLaunchForce();
        healthSlider.value = tankController.GetHealth();
        shellSpawner = FindObjectOfType<ShellSpawner>();
        uiController = FindObjectOfType<UIController>();
    }

    private void Update()
    {
        Movement();
        MoveTank();
        tankController.FireProcess();
    }
    
    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
    
    private void MoveTank()
    {
        if (movement != 0)
        {
            tankController.Move(movement,tankController.GetMovementSpeed());
        }

        if (rotation != 0)
        {
            tankController.Rotate(rotation,tankController.GetRotationSpeed());
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
        tankController.SetFiredState(true);
        StartCoroutine(cameraShake.Shake(0.1f, 0.1f)); 
        shellSpawner.SpawnShell(fireTransform.position,fireTransform.rotation,tankController.GetCurrentLaunchForce(),fireTransform.forward,ShellParentType.PLAYERTANK);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (tankController.GetHealth() >= 0)
        {
            if (other.gameObject.GetComponent<ShellView>().GetShellParentType() == ShellParentType.ENEMYTANK)
            {
                tankController.TakeDamage(5);
            }
        }
        else
        {
            Destroy(gameObject);
            uiController.GameOverMenu();
        }
    }

    public Vector3 GetTankTransform()
    {
        return transform.forward;
    }
    
    public float GetDamagePower()
    {
        return tankController.GetDamagePower();
    }
    public Slider GetAimSlider()
    {
        return aimSlider;
    }

    public Slider GetHealthSlider()
    {
        return healthSlider;
    }
    public Rigidbody GetRigidbody()
    {
        return rb;
    }
}
