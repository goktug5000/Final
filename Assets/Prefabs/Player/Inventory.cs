using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject itemUiPrefab;
    public Transform itemParent;
    public List<CollectableItem> items;

    public void AddItem(CollectableItem item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemSo == item?.itemSo)
            {
                items[i].amount += item.amount;

                item = null;
                break;
            }
        }
        if (item != null)
        {
            items.Add(item);
        }
        GenerateInventory();
    }

    public void GenerateInventory()
    {
        foreach (Transform child in itemParent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < items.Count; i++)
        {
            SpawnItem(i);
        }
    }

    public void SpawnItem(int i)
    {
        GameObject newItem = Instantiate(itemUiPrefab, itemParent);
        RectTransform rectTransform = newItem.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = new Vector2(100, (i * -150) - 120);
        }
        ItemButton itemButton = newItem.GetComponent<ItemButton>();
        if (itemButton != null)
        {
            itemButton.SetButton(items[i]);
        }
    }
}
