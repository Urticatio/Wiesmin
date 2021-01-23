using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject canvas;
    private void Start()
    {
        canvas = GameObject.Find("Canvas");
    }

    public void PlayGame()
    {
        //włącza następną w kolejce scenę
        StartCoroutine(NewGame_Coroutine());
    }
    IEnumerator NewGame_Coroutine()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        yield return null; //czeka aż się scena wczyta
        Destroy(canvas);
    }
    public void LoadGame()
    {
        StartCoroutine(LoadGame_Coroutine());         
    }
    IEnumerator LoadGame_Coroutine()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        yield return null; //czeka aż się scena wczyta
        Debug.Log("Wczytuję zapisaną grę");
        GameManager.instance.saveLoadController.LoadGame();
        Destroy(canvas);

    }

    public void QuitGame()
    {
        Debug.Log("Zamykam grę");
        Application.Quit();
    }

}
