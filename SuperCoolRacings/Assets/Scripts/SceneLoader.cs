﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    public void StartPlaying() {
        SceneManager.LoadScene("GameScene_Island");
    }

    public void ToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit() {
    #if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
    #else
         Application.Quit();
     #endif
    }
}