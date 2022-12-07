using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //New
    public GameObject HoverObject;
    public void PlayGame()
    {
        HoverObject.SetActive(true);
        HoverObject.SetActive(false);;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void GoMainMenu()
    {
        PlayerPrefs.DeleteKey("timer");
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        HoverObject.SetActive(true);
        PlayerPrefs.DeleteKey("timer");
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
