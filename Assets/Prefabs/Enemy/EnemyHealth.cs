using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class EnemyHealth : Health
{
    [SerializeField] private EnemyRoot myEnemyRoot;
    [SerializeField] private TextMeshPro healthText;

    public override void TakeDamage(GameObject hitter, float damage)
    {
        base.TakeDamage(hitter, damage);
        UpdateHpBar();
    }

    public override void Regen()
    {
        base.Regen();
        UpdateHpBar();
    }

    public void UpdateHpBar()
    {
        healthText.text = Mathf.FloorToInt(HP).ToString() + "/" + Mathf.FloorToInt(HP_Max).ToString();
    }

    public override void Die()
    {
        Debug.Log(this.gameObject.name + " öldü");

        myEnemyRoot.enemyInventory.Die();
        if (myEnemyRoot.enemySpawner != null)
        {
            myEnemyRoot.enemySpawner.Spawn();
        }
        Dying();
    }

    public async Task Dying()
    {

        await Task.Delay(4000);
        Destroy(myEnemyRoot.gameObject);
    }
}
