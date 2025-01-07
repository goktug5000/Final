using System.Threading.Tasks;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField] private EnemyRoot myEnemyRoot;

    private EnemyMovement enemyMovement;
    private EnemyHealth enemyHealth;
    private Animator enemyAnimator;

    [SerializeField] private float attackDisttance;
    [SerializeField] public float damage;

    [SerializeField] private float attackCD;
    public bool attacking;
    private bool canAttack = true;

    void Start()
    {
        enemyMovement = myEnemyRoot.enemyMovement;
        enemyAnimator = myEnemyRoot.holderAnimator;
        enemyHealth = myEnemyRoot.enemyHealth;
    }

    void Update()
    {
        if (!enemyHealth.dead)
        {
            CheckAttack();
        }
    }

    async Task CheckAttack()
    {
        if (enemyMovement.distance <= attackDisttance && enemyMovement.follow && canAttack)
        {
            await Attack();
        }
    }

    private async Task Attack()
    {
        canAttack = false;
        attacking = true;
        enemyAnimator.SetTrigger("Attack");
        await Task.Delay((int)(attackCD * 1000));
        canAttack = true;
    }
}
