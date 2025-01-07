using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Story")]
public class StorySO : ScriptableObject
{
    [SerializeField] public string storyText;
    [SerializeField] public Sprite storyImage;
    [SerializeField] public bool isPlayer;
}
