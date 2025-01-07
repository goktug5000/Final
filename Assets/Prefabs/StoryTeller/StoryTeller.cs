using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTeller : MonoBehaviour
{
    [SerializeField] private GameObject dialog;
    [SerializeField] private StorySO[] storySOs;

    private void Start()
    {
        dialog.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!StoryPrefab._storyPrefab.inStory)
            {
                dialog.SetActive(true);
            }
            else
            {
                dialog.SetActive(false);
            }

            if (Input.GetKeyDown(KeyBindings.KeyCodes[KeyBindings.KeyCode_Interaction]) && !StoryPrefab._storyPrefab.inStory)
            {
                dialog.SetActive(false);
                StoryPrefab._storyPrefab.StartStory(storySOs);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialog.SetActive(false);
        }
    }
}
