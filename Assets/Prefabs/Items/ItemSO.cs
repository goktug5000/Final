using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item")]
public class ItemSO : ScriptableObject
{
    [Header("ItemScriptableObject")]
    public string objName;
    public string shortDesc;
    public string desc;
    public Sprite objImage;
    public float singlePrice;

    public GameObject itemPrefab;

    public virtual void MyClickEvent()
    {
        Debug.Log(objName);
    }
}
