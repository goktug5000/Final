using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInventory : MonoBehaviour
{
    public List<CollectableItem> items;
    public GameObject collectableHolder;
    
    public void Die()
    {
        foreach(var item in items)
        {
            var newItem = Instantiate(collectableHolder);
            newItem.transform.position = this.transform.position;
            newItem.GetComponent<Rigidbody>().AddForce(200 * Vector3.forward);
            newItem.GetComponent<CollectableHolder>().StartMe(item);
        }
    }
}
