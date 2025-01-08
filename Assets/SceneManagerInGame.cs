using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerInGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(loadThis("Ending"));
        }
    }

    IEnumerator loadThis(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        yield return null;
    }
}
