using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerInGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(loadThis("Ending"));
        }
    }



    static public bool isFullyLoaded;
    IEnumerator loadThis(string sceneName)
    {
        isFullyLoaded = false;
        SceneManager.LoadScene(sceneName);
        isFullyLoaded = true;

        yield return null;
    }
}
