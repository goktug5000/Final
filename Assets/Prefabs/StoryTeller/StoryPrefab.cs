using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryPrefab : MonoBehaviour
{
    public static StoryPrefab _storyPrefab;
    
    [SerializeField] private GameObject menu;
    [SerializeField] private Transform content;
    [SerializeField] private GameObject storyHolder;
    [SerializeField] private RawImage tellerImage;
    public bool inStory;
    
    private void Awake()
    {
        if(_storyPrefab == null)
        {
            _storyPrefab = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        menu.SetActive(false);
        ClearContent();
    }

    private void ClearContent()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }

    public void StartStory(StorySO[] storySOs)
    {
        ClearContent();
        inStory = true;
        StartCoroutine(StoryMode(storySOs));
        inStory = false;
    }

    public IEnumerator StoryMode(StorySO[] storySOs)
    {
        Time.timeScale = 0.1f;
        menu.SetActive(true);
        int i = 0;
        foreach (var storySo in storySOs)
        {
            SpawnStory(storySo, i);
            i++;
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(0.4f);
        yield return new WaitUntil(() => Input.GetKey(KeyBindings.KeyCodes[KeyBindings.KeyCode_Interaction]));

        Time.timeScale = 1;
        menu.SetActive(false);
    }

    public void SpawnStory(StorySO storySO, int i)
    {
        GameObject newItem = Instantiate(storyHolder, content);
        RectTransform rectTransform = newItem.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = new Vector2(0, (i * -150) - 100);
        }
        StoryItem item = newItem.GetComponent<StoryItem>();
        if (storySO.storyImage != null)
        {
            tellerImage.gameObject.SetActive(true);
            tellerImage.texture = storySO.storyImage.texture;
        }
        else
        {
            tellerImage.gameObject.SetActive(false);
        }

        if (item != null)
        {
            item.StartMe(storySO);
        }
    }
}
