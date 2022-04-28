using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menumanager : MonoBehaviour
{
    public GameObject ControlMenu;


    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void ShowControlMenu()
    {
        ControlMenu.SetActive(true);
    }

    public void HideControlMenu()
    {
        ControlMenu.SetActive(false);
    }
        
}
