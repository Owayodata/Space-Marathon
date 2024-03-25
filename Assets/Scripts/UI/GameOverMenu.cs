using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("TheGame");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
