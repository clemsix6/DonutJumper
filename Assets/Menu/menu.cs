using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void LoadSceneGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadSceneSettings()
    {
        SceneManager.LoadScene("Option");
    }
    public void LoadSceneQuit()
    {
        Application.Quit();
    }
}
