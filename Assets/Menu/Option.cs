using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public Image oldImage;
    public Sprite newImage;
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadSceneQuitOption()
    {
        Application.Quit();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Menu");
    }
    public void ChangeButton()
    {
        oldImage.sprite = newImage;
    }
}