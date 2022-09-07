using UnityEngine;
using UnityEngine.AI;

public class EnemyLogic : MonoBehaviour
{
    [SerializeField] private ScriptableObjectLogic EnemyHealth;
    [SerializeField] private Transform player;
    private Animator animator;
    private Rigidbody EnemyRB;
    [SerializeField] private float findDist;
    private float dist;
    private NavMeshAgent agent;
    public Rigidbody[] partsOfBody;


    void Start()
    {
        animator = GetComponent<Animator>();
        //EnemyRB = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        for (int i = 0; i < partsOfBody.Length; i++)
        {
            partsOfBody[i].isKinematic = true;
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Move();
        
        
    }
    void Die()
    {
        animator.enabled = false;
        agent.enabled = false;
        for (int i = 0; i < partsOfBody.Length; i++)
        {
            partsOfBody[i].isKinematic = false;
        }
    }
    void PlayerFinder()
    { 
        
    }
    private void Move()
    {
        agent.SetDestination(player.position);
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
    public void Hurt(int damage)
    {
        EnemyHealth.Value -= damage;
        if (EnemyHealth.Value <= 0)
        {
            Die();
        }
    }
        
}
