using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //włącza następną w kolejce scenę
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
    }

    public void LoadGame()
    {
        /*TODO*/

        ////////
    }

    public void QuitGame()
    {
        Debug.Log("Zamykam grę");
        Application.Quit();
    }

}
