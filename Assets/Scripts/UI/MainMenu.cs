using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("TheGame");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene("Options");
    }
    public void StoreButton()
    {
        SceneManager.LoadScene("Store");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
