using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    public void PlayEarth(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void PlaySpace(string level)
    {
 
        SceneManager.LoadScene(level);
    }
    public void PlaySea(string level)
    {
        SceneManager.LoadScene(level);
    }
}