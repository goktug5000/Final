using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Quest")]
public class QuestSO : ScriptableObject
{
    [SerializeField] public string questName;
    [SerializeField] public string description;
    [SerializeField] public List<CollectableItem> gets;
    [SerializeField] public List<CollectableItem> haves;
    [SerializeField] public QuestGiverSO QuestGiverSO;
}
