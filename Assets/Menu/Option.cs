using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite on;
    [SerializeField] private Sprite off;


    private void Start()
    {
        this.image.sprite = CameraMoving.multiplayer ? on : off;
    }


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
        image.sprite = CameraMoving.multiplayer ? off : on;
        CameraMoving.multiplayer = !CameraMoving.multiplayer;
    }
}