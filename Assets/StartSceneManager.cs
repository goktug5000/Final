using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public GameObject Yuzz;
    public void StartGame()
    {
        StartCoroutine(loadThis("SampleScene"));
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Yuz()
    {
        Yuzz.SetActive(true);
    }
    public void CloseYuz()
    {
        Yuzz.SetActive(false);
    }

    IEnumerator loadThis(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        yield return null;
    }
}
