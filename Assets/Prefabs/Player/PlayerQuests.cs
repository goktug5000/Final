using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerQuests : MonoBehaviour
{
    [SerializeField] private GameObject questHolder;
    [SerializeField] private Transform questParent;
    private Inventory playerInventory;
    public List<QuestSO> questSOs;

    private void Start()
    {
        playerInventory = PlayerConstantsHolder._playerConstantsHolder.playerInventory;
        GenerateQuests();
    }

    public void AddQuest(QuestSO questSO)
    {
        questSOs.Add(questSO);
        GenerateQuests();
    }

    public List<QuestSO> CheckQuests(QuestGiverSO giverSO)
    {
        List<QuestSO> compQuests = new List<QuestSO>();

        foreach (var questSo in questSOs)
        {
            if (giverSO == questSo.QuestGiverSO)
            {
                if (CheckIfContainsAll(questSo.gets))
                {
                    compQuests.Add(questSo);
                }
            }
        }
        return compQuests;
    }

    public bool CheckIfContainsAll(List<CollectableItem> listA)
    {
        foreach (var item in listA)
        {
            var itemInv = playerInventory.items.FirstOrDefault(x => x.itemSo == item.itemSo);
            if (itemInv == null || item.amount > itemInv.amount)
            {
                return false;
            }
        }

        return true;
    }

    public void ComplateQuest(QuestSO questSo)
    {
        if (CheckIfContainsAll(questSo.gets))
        {
            RemoveIfContainsAll(questSo.gets);
            foreach (var a in questSo.haves)
            {
                playerInventory.AddItem(a);
            }
        }
        questSOs.Remove(questSo);
        GenerateQuests();
    }

    public void RemoveIfContainsAll(List<CollectableItem> listA)
    {
        foreach (var item in listA)
        {
            var itemInv = playerInventory.items.FirstOrDefault(x => x.itemSo == item.itemSo);
            itemInv.amount -= item.amount;
            if(itemInv.amount == 0)
            {
                playerInventory.items.Remove(itemInv);
            }
        }
        playerInventory.GenerateInventory();
    }

    public void GenerateQuests()
    {
        foreach (Transform child in questParent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < questSOs.Count; i++)
        {
            SpawnQuest(i);
        }
    }

    public void SpawnQuest(int i)
    {
        GameObject newItem = Instantiate(questHolder, questParent);
        RectTransform rectTransform = newItem.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = new Vector2(100, (i * -150) - 120);
        }
        QuestButton itemButton = newItem.GetComponent<QuestButton>();
        if (itemButton != null)
        {
            itemButton.SetQuest(questSOs[i]);
        }
    }
}
