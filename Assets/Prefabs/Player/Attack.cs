using System.Threading.Tasks;
using UnityEngine;
using TMPro;

public class Attack : MonoBehaviour
{
    public static Attack _attack;
    private Animator playerAnimator;
    public bool inAttackAnim;

    public GlobalConstans.WeaponTypes WeaponType;
    [SerializeField] private GameObject redDot;
    public LayerMask raycastLayerMask;

    public float damageBase;
    [SerializeField] private TextMeshProUGUI damageText;

    void Awake()
    {
        if (_attack != null)
        {
            Destroy(this);
        }
        else
        {
            _attack = this;
        }

        playerAnimator = PlayerConstantsHolder._playerConstantsHolder.holderAnimator;
    }

    void Start()
    {
        UpdateDamageText();
    }

    void Update()
    {
        PlayerAttack();
        //RedDot(); // TODO: spell koyarsan aç geri
    }

    void OnDrawGizmos()
    {
        if (PlayerConstantsHolder._playerConstantsHolder?.hitBoxes.Length > 0)
        {
            foreach (var hitBox in PlayerConstantsHolder._playerConstantsHolder.hitBoxes)
            {
                if (hitBox != null)
                {
                    Gizmos.color = Color.red; // Set the color for the Gizmo
                    Gizmos.DrawWireSphere(hitBox.transform.position, 0.1f); // Draw the overlap sphere
                }
            }
        }
    }

    public void SwichWeapon(WeaponSO weaponSO)
    {
        WeaponType = weaponSO.weaponType;
        playerAnimator.SetInteger("WeaponType", (int)weaponSO.weaponType);
        damageBase = weaponSO.attackDamage;
        UpdateDamageText();
    }

    public void UpdateDamageText()
    {
        damageText.text = damageBase.ToString();
    }

    void RedDot()
    {
        redDot.SetActive(false);
        if (WeaponType == GlobalConstans.WeaponTypes.Spell && Input.GetKey(KeyBindings.KeyCodes[KeyBindings.KeyCode_Attack2]))
        {
            PlayerConstantsHolder._playerConstantsHolder.virtualCameraTPS.Priority = 15;
        }
        else
        {
            PlayerConstantsHolder._playerConstantsHolder.virtualCameraTPS.Priority = 5;
            return;
        }

        Ray ray = new Ray(PlayerConstantsHolder._playerConstantsHolder.virtualCameraTP.transform.position, PlayerConstantsHolder._playerConstantsHolder.virtualCameraTP.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, raycastLayerMask))
        {
            redDot.SetActive(true);
            redDot.transform.position = hit.point;
        }

    }

    async Task PlayerAttack()
    {
        if (Input.GetKeyDown(KeyBindings.KeyCodes[KeyBindings.KeyCode_Attack1]))
        {
            if (WeaponType == GlobalConstans.WeaponTypes.GreatSword)
            {
                if (Movement._movement.CanDash())
                {
                    playerAnimator.SetTrigger("Attack1");
                    await Movement._movement.DashAsync(500, 0.2f);
                }
            }
            else if (WeaponType == GlobalConstans.WeaponTypes.Gauntlet)
            {
                playerAnimator.SetTrigger("CM_Attack_1");
            }
            else if (WeaponType == GlobalConstans.WeaponTypes.Spell)
            {
                playerAnimator.SetTrigger("CM_Attack_1");
            }
            else if (WeaponType == GlobalConstans.WeaponTypes.Sword)
            {
                playerAnimator.SetTrigger("Attack1");
            }
        }
        else if (Input.GetKeyDown(KeyBindings.KeyCodes[KeyBindings.KeyCode_Attack2]))
        {
            if (WeaponType == GlobalConstans.WeaponTypes.Gauntlet)
            {
                playerAnimator.SetTrigger("CM_Attack_2");
            }
        }
    }
}
