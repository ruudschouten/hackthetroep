using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {
    public void StartPlaying() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene_Island");
    }

    public void QuitGame() {
        // save any game data here
        #if UNITY_EDITOR
                // Application.Quit() does not work in the editor so
                // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
                UnityEditor.EditorApplication.isPlaying = false;
        #else
         Application.Quit();
     #endif
    }
}