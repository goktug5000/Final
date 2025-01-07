using UnityEngine;
using TMPro;

public class CollectableHolder : MonoBehaviour
{
    public Inventory inventory;
    [SerializeField] public CollectableItem item;
    [SerializeField] public TextMeshPro textt;

    private void Start()
    {
        inventory = PlayerConstantsHolder._playerConstantsHolder.playerInventory;
        if(item != null)
        {
            StartMe(item);
        }
    }

    public void StartMe(CollectableItem itemm)
    {
        item = itemm;
        var newItem = Instantiate(item.itemSo.itemPrefab, this.transform);
        textt.text = item.itemSo.objName;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyBindings.KeyCodes[KeyBindings.KeyCode_Interaction]))
        {
            CollectMe();
        }
    }

    public void CollectMe()
    {
        if (item?.itemSo != null)
        {
            inventory.AddItem(item);
        }
        Destroy(this.gameObject);
    }
}
