using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyRoot myEnemyRoot;

    private Transform target;
    private NavMeshAgent agent;
    private Animator enemyAnimator;
    private EnemyMeleeAttack enemyMeleeAttack;
    private EnemyHealth enemyHealth;

    [SerializeField] private float stopDistance = 1.2f;
    public bool follow;
    [SerializeField] private int followDistance;
    public float distance = Mathf.Infinity;
    public float movementSpeed = 5;

    public Transform transformA;  // Baþlangýç noktasý
    public Transform transformB;  // Bitiþ noktasý

    private void Start()
    {
        target = myEnemyRoot.target;
        agent = myEnemyRoot.agent;
        enemyAnimator = myEnemyRoot.holderAnimator;
        enemyMeleeAttack = myEnemyRoot.enemyMeleeAttack;
        enemyHealth = myEnemyRoot.enemyHealth;

        agent.stoppingDistance = stopDistance;
        agent.speed = movementSpeed;
    }

    void Update()
    {
        if (!enemyHealth.dead)
        {
            distance = agent.remainingDistance;
            Movement();
        }
    }

    void Movement()
    {
        if (follow)
        {
            target.position = PlayerConstantsHolder._playerConstantsHolder.holderTipObj.transform.position;
        }
        if (!follow && distance <= stopDistance)
        {
            target.position = GetRandomPosition(transformA.position, transformB.position);
        }

        if (distance > stopDistance)
        {
            enemyAnimator.SetBool("Run", true);
            if (CanRotate())
            {
                agent.speed = movementSpeed;
                agent.stoppingDistance = stopDistance;
            }
        }
        else
        {
            enemyAnimator.SetBool("Run", false);
            if (CanRotate())
            {
                agent.stoppingDistance = 0;
                agent.speed = 0.1f;
            }
        }
        agent.SetDestination(target.position);
    }

    private bool CanRotate()
    {
        return !enemyMeleeAttack.attacking;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            follow = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            follow = false;
        }
    }

    Vector3 GetRandomPosition(Vector3 pointA, Vector3 pointB)
    {
        float randomX = Random.Range(pointA.x, pointB.x);
        float randomY = Random.Range(pointA.y, pointB.y);
        float randomZ = Random.Range(pointA.z, pointB.z);

        return new Vector3(randomX, randomY, randomZ);
    }
}
