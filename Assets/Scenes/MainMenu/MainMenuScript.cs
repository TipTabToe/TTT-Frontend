using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {
    public void Play() {
        SceneLoader.Load(SceneLoader.Scene.PlayMenu);
    }

    public void Options() {
        SceneLoader.LoadWithLoader(SceneLoader.Scene.Options);
    }
    
    public void Quit() {
        Debug.Log("Quit pressed.");
        Application.Quit();
    }
}