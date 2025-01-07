using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Weapon")]
public class WeaponSO : WearableItem
{
    [Header("WeaponScriptableObject")]
    public float attackDamage;
    public GlobalConstans.WeaponTypes weaponType;

    public override void MyClickEvent()
    {
        PlayerConstantsHolder._playerConstantsHolder.playerEquipment.EquipThis(this);
    }
}
