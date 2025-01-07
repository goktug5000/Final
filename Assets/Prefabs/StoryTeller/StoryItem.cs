using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryItem : MonoBehaviour
{
    [SerializeField] private RawImage chatBg;
    [SerializeField] private TextMeshProUGUI textt;

    public void StartMe(StorySO storySO)
    {
        if (!storySO.isPlayer)
        {
            chatBg.rectTransform.localScale = new Vector3(
                -chatBg.rectTransform.localScale.x,
                chatBg.rectTransform.localScale.y,
                chatBg.rectTransform.localScale.z);
        }
        textt.text = storySO.storyText;
    }
}
