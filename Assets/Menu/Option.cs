using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Menu");
    }
    public void LoadSceneQuitOption()
    {
        Application.Quit();
    }
}