using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {
    
    SignUpPopUp popupWindow;
    GameObject gameController;
    private bool loggedIn = false;
    
    void Start () {
        gameController = GameObject.Find("GameController");
        popupWindow = gameController.GetComponent<SignUpPopUp> ();
    }
    
    public void Play() {
        SceneLoader.Load(SceneLoader.Scene.CreateGame);
    }

    public void Options() {
        SceneLoader.LoadWithLoader(SceneLoader.Scene.Friendlist);
    }
    
    public void Quit() {
        Debug.Log("Quit pressed.");
        Application.Quit();
    }
}