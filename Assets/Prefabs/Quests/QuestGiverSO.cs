using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/QuestGiver")]
public class QuestGiverSO : ScriptableObject
{
    [SerializeField] public string questGiverName;
}
