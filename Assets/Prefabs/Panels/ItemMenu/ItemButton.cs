using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemButton : MonoBehaviour
{
    public RawImage itemIamge;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI shortDescText;
    public TextMeshProUGUI amountText;
    public CollectableItem item;

    public void SetButton(CollectableItem itemm)
    {
        item = itemm;
        if (item?.itemSo?.objImage?.texture != null)
        {
            itemIamge.texture = item.itemSo.objImage.texture;
        }
        nameText.text = item.itemSo.objName;
        shortDescText.text = item.itemSo.shortDesc;
        amountText.text = item.amount.ToString();
    }

    public void ClickedOnMe()
    {
        item.itemSo.MyClickEvent();
    }
}
