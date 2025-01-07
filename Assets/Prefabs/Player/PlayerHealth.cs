using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public class PlayerHealth : Health
{
    public RectTransform HPRect;
    private Movement movement;

    public void Start()
    {
        base.Start();
        movement = PlayerConstantsHolder._playerConstantsHolder.playerMovement;
    }

    public override void TakeDamage(GameObject hitter, float damage)
    {
        base.TakeDamage(hitter, damage);
        DamageKnockbackAsync(hitter);
        UpdateHpBar();
    }

    private async Task DamageKnockbackAsync(GameObject hitter)
    {
        Vector3 direction = hitter.transform.position - transform.position;
        await movement.DashAsync(250, 1f, direction.normalized);
    }

    public override void Regen()
    {
        base.Regen();
        UpdateHpBar();
    }

    public void UpdateHpBar()
    {
        var hpPercentage = HP / HP_Max;
        HPRect.sizeDelta = new Vector2(HPRect.sizeDelta.x, HPRect.sizeDelta.x * hpPercentage);
    }

    public override void Die()
    {
        Debug.Log("Player öldü");
    }
}
