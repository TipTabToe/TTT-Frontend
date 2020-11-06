using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {
    
    SignUpPopUp popupWindow;
    GameObject gameController;
    
    void Start () {
        gameController = GameObject.Find("GameController");
        popupWindow = gameController.GetComponent<SignUpPopUp> ();
    }
    
    public void Play() {
        // if logged in
        // SceneLoader.Load(SceneLoader.Scene.PlayMenu);
        // else
        popupWindow.Open();
    }

    public void Options() {
        SceneLoader.LoadWithLoader(SceneLoader.Scene.Options);
    }
    
    public void Quit() {
        Debug.Log("Quit pressed.");
        Application.Quit();
    }
}