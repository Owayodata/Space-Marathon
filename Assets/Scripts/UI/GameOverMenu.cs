using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void Restart()
    {
        PlayerMovement.movementSpeed = 5f;
        SceneManager.LoadScene("TheGame");
    }
    public void MainMenu()
    {
        PlayerMovement.movementSpeed = 5f;
        SceneManager.LoadScene("MainMenu");
    }
}
