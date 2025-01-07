using UnityEngine;

public class DuringAttack : StateMachineBehaviour
{
    [SerializeField] private bool inAttackAnimB;
    [SerializeField] private float damageMulti = 1;
    private GameObject[] hitBoxes = null;
    private bool hitted = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hitBoxes = PlayerConstantsHolder._playerConstantsHolder.hitBoxes;
        hitted = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Attack._attack.inAttackAnim = inAttackAnimB; // TODO: bunlarý tek yere taþý PlayerConstansHolder olabilir
        Movement._movement.inAttackAnim = inAttackAnimB;

        if (hitBoxes.Length > 0 && stateInfo.normalizedTime >= 0.3f)
        {
            foreach (var hitBox in hitBoxes)
            {
                if (hitBox != null)
                {
                    var trailRenderer = hitBox.GetComponent<TrailRenderer>();
                    if (trailRenderer != null)
                    {
                        trailRenderer.enabled = true;
                    }

                    if (!hitted)
                    {
                        Collider[] hitColliders = Physics.OverlapSphere(hitBox.transform.position, 0.1f); // 1f is the radius

                        foreach (var hitCollider in hitColliders)
                        {
                            if (!hitCollider.isTrigger)
                            {
                                IDamageable damageable = hitCollider.GetComponent<IDamageable>();
                                if (damageable != null && hitCollider.gameObject.tag != "Player" && hitCollider.gameObject.tag != "Untagged")
                                {
                                    damageable.TakeDamage(animator.gameObject, Attack._attack.damageBase * damageMulti);
                                    hitted = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.SetLayerWeight(layerNo, 0);
        Attack._attack.inAttackAnim = false;
        Movement._movement.inAttackAnim = false;
        foreach (var hitBox in hitBoxes)
        {
            if (hitBox != null)
            {
                var trailRenderer = hitBox.GetComponent<TrailRenderer>();
                if (trailRenderer != null)
                {
                    trailRenderer.enabled = false;
                }
            }
        }
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
}