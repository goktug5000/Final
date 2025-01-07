using UnityEngine;

public abstract class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float hp;
    [SerializeField] private float hpMax;
    [SerializeField] private float hpRegen;
    private bool isImmune;
    public bool dead;
    private Animator anim;

    public void Start()
    {
        SetAnimator();
    }

    void SetAnimator()
    {
        Transform current = gameObject.transform;

        while (current != null)
        {
            ConstantHolder testComponent = current.GetComponent<ConstantHolder>();
            if (testComponent != null)
            {
                anim = testComponent.GetComponent<ConstantHolder>().holderAnimator;
            }
            current = current.parent;
        }
    }

    public virtual float HP
    {
        get => hp;
        set => hp = Mathf.Clamp(value, 0, HP_Max);
    }
    public virtual float HP_Max
    {
        get => hpMax;
        set => hpMax = Mathf.Max(0, value);
    }
    public virtual float HP_Regen
    {
        get => hpRegen;
        set => hpRegen = Mathf.Max(0, value);
    }
    public virtual bool IsImmune
    {
        get => isImmune;
        set => isImmune = value;
    }
    public virtual bool Dead
    {
        get => dead;
        set => dead = value;
    }
    public virtual void TakeDamage(GameObject hitter, float damage)
    {
        if (IsImmune || Dead)
        {
            return;
        }

        HP -= damage;

        if (HP <= 0)
        {
            HP = 0;
            Dead = true;
            anim.SetTrigger("dead");
            Die();
        }
        else
        {
            anim.SetTrigger("TakeDmg");
        }
    }
    public virtual void Regen()
    {
        if (!Dead)
        {
            if (HP < HP_Max)
            {
                HP += HP_Regen * Time.deltaTime;
            }
            else
            {
                HP = HP_Max;
            }
        }
    }
    public abstract void Die();
    void Update()
    {
        Regen();
    }
}
