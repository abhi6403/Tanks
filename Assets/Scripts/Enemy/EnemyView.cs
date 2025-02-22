using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{
    private EnemyController enemyController;
    private TankView tankView;
    public Vector3 DirectionToPlayer { get; private set; }
    public bool isPlayerFound { get; private set; }

    [SerializeField] private MeshRenderer[] childs;
    [SerializeField] private ParticleSystem particleExplosion;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float targetDistance;
    
    private Rigidbody rb;
    private Vector3 targetDirection;
    private float timer;
    
    private void Start()
    {
        enemyController.Start();
        tankView = FindObjectOfType<TankView>();
        healthSlider.value = enemyController.GetHealth();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckForPlayer();
        enemyController.Update();
    }
    private void CheckForPlayer()
    {
        Vector3 enemyToPlayerVector = tankView.transform.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;
        float distanceToPlayer = enemyToPlayerVector.magnitude;

        float buffer = .2f;

        if (distanceToPlayer <= targetDistance - buffer)
        {
            isPlayerFound = true;
        }
        else if (distanceToPlayer >= targetDistance + buffer)
        {
            isPlayerFound = false;
        }
    }
    
    private void FixedUpdate()
    {
        if (enemyController != null)
        {
            enemyController.UpdateTargetDirection();
            enemyController.RotateTowardsTarget();
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (enemyController.GetHealth() > 0)
        {
            if (other.gameObject.GetComponent<ShellView>().GetShellParentType() == ShellParentType.PLAYERTANK)
            {
                enemyController.TakeDamage(10);
            }
        }
        else
        {
            spawnDamageParticles();
            Destroy(gameObject);
        }
    }
    public void setEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
    
    private void spawnDamageParticles()
    {
        Instantiate(particleExplosion, transform.position, Quaternion.identity);
    }
    public void ChangeColor(Material color)
    {
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].material = color;
        }
    }

    public TankView GetTankView()
    {
        return tankView;
    }
    public Slider GetHealthSlider()
    {
        return healthSlider;
    }
    public void SetTankPosition(Transform poi)
    {
       gameObject.transform.position = poi.position;
    }

    public Transform GetFireTransform()
    {
        return fireTransform;
    }
}
