using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    private Attack playerAttack;

    [Header("PlayerTransforms")]
    [SerializeField] public Transform head;
    [SerializeField] public GameObject headItem;
    [SerializeField] public RawImage headImage;

    [SerializeField] public Transform body;
    [SerializeField] public GameObject bodyItem;
    [SerializeField] public RawImage bodyImage;

    [SerializeField] public Transform rightHand;
    [SerializeField] public GameObject rightHandItem;
    [SerializeField] public RawImage rightHandImage;

    [SerializeField] public Transform leftHand;
    [SerializeField] public GameObject leftHandItem;
    [SerializeField] public RawImage leftHandImage;

    [SerializeField] public WeaponSO defaultWeapon;

    private void Start()
    {
        playerAttack = PlayerConstantsHolder._playerConstantsHolder.playerAttack;

        headImage.gameObject.SetActive(false);
        bodyImage.gameObject.SetActive(false);
        rightHandImage.gameObject.SetActive(false);
        leftHandImage.gameObject.SetActive(false);

        WearNew(defaultWeapon);
    }

    public void EquipThis(WearableItem wearableItem)
    {
        RemovePrev(wearableItem);
        WearNew(wearableItem);
    }

    public void UnEquipHands()
    {
        RemovePrev(new WearableItem { rightHand = true, leftHand = true });
        WearNew(defaultWeapon);
    }

    public void UnEquipHead()
    {
        RemovePrev(new WearableItem { head = true });
    }

    public void UnEquipBody()
    {
        RemovePrev(new WearableItem { body = true });
    }

    void WearNew(WearableItem wearableItem)
    {
        if (wearableItem.itemPrefab)
        {
            if (wearableItem.head)
            {
                headItem = Instantiate(wearableItem.itemPrefab, head);
                headImage.gameObject.SetActive(true);
                headImage.texture = wearableItem.objImage.texture;
            }
            if (wearableItem.body)
            {
                bodyItem = Instantiate(wearableItem.itemPrefab, body);
                bodyImage.gameObject.SetActive(true);
                bodyImage.texture = wearableItem.objImage.texture;
            }
            if (wearableItem.rightHand)
            {
                rightHandItem = Instantiate(wearableItem.itemPrefab, rightHand);
                rightHandImage.gameObject.SetActive(true);
                rightHandImage.texture = wearableItem.objImage.texture;
            }
            if (wearableItem.leftHand)
            {
                leftHandItem = Instantiate(wearableItem.itemPrefab, leftHand);
                leftHandImage.gameObject.SetActive(true);
                leftHandImage.texture = wearableItem.objImage.texture;
            }
        }
        if (wearableItem is WeaponSO weaponSO)
        {
            playerAttack.SwichWeapon(weaponSO);
            SetHitbox();
        }
    }

    public void SetHitbox()
    {
        PlayerConstantsHolder._playerConstantsHolder.hitBoxes[0] = null;
        PlayerConstantsHolder._playerConstantsHolder.hitBoxes[1] = null;

        if (rightHandItem != null && rightHandItem.gameObject.GetComponent<WeaponPrefab>()?.hitbox)
        {
            PlayerConstantsHolder._playerConstantsHolder.hitBoxes[0] = rightHandItem.gameObject.GetComponent<WeaponPrefab>().hitbox;
        }
        if (leftHandItem != null && leftHandItem.gameObject.GetComponent<WeaponPrefab>()?.hitbox)
        {
            PlayerConstantsHolder._playerConstantsHolder.hitBoxes[1] = leftHandItem.gameObject.GetComponent<WeaponPrefab>().hitbox;
        }
    }

    void RemovePrev(WearableItem wearableItem)
    {
        if (wearableItem.head)
        {
            Destroy(headItem);
            headImage.gameObject.SetActive(false);
        }
        if (wearableItem.body)
        {
            Destroy(bodyItem);
            bodyImage.gameObject.SetActive(false);
        }
        if (wearableItem.rightHand || wearableItem.leftHand)
        {
            Destroy(rightHandItem);
            Destroy(leftHandItem);
            rightHandImage.gameObject.SetActive(false);
            leftHandImage.gameObject.SetActive(false);
        }
    }
}
