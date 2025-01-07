using UnityEngine;
using UnityEngine.AI;

public class EnemyDuringAttack : StateMachineBehaviour
{
    private EnemyRoot myEnemyRoot;

    private NavMeshAgent agent;
    private EnemyMeleeAttack enemyMeleeAttack;
    public GameObject hitBox;

    private float preSpeed;
    private bool hitted = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SetMyEnemyRoot(animator.gameObject);

        agent = myEnemyRoot.agent;
        enemyMeleeAttack = myEnemyRoot.enemyMeleeAttack;
        hitBox = myEnemyRoot.hitBox;

        preSpeed = agent.speed;
        enemyMeleeAttack.attacking = true;
        agent.speed = 0;
        hitted = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= 0.3f)
        {
            hitBox.GetComponent<TrailRenderer>().enabled = true;
            if (!hitted)
            {
                Collider[] hitColliders = Physics.OverlapSphere(hitBox.transform.position, 0.1f); // 1f, etrafýndaki 1 birimlik alan

                foreach (var hitCollider in hitColliders)
                {
                    IDamageable damageable = hitCollider.GetComponent<IDamageable>();

                    if (damageable != null && hitCollider.gameObject.tag != "Enemy")
                    {
                        hitted = true;
                        damageable.TakeDamage(animator.gameObject, enemyMeleeAttack.damage);
                    }
                }
            }
        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.speed = preSpeed;
        enemyMeleeAttack.attacking = false;
        hitBox.GetComponent<TrailRenderer>().enabled = false;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}

    private void SetMyEnemyRoot(GameObject me)
    {
        Transform currentTransform = me.transform;
        while (currentTransform != null)
        {
            myEnemyRoot = currentTransform.GetComponent<EnemyRoot>();

            if (myEnemyRoot != null)
            {
                break;
            }
            currentTransform = currentTransform.parent;
        }
    }
}
