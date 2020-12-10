using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contains the functionality of MainMenu
public class MainMenuScript : MonoBehaviour {
    
    SignUpPopUp popupWindow;
    GameObject gameController;
    private PlayerSettings playerSettings;

    void Start () {
        gameController = GameObject.Find("GameController");
        popupWindow = gameController.GetComponent<SignUpPopUp> ();
        playerSettings = gameController.GetComponent<PlayerSettings>();
    }
    // Moves to playing the game
    public void Play() {
        SceneLoader.Load(SceneLoader.Scene.CreateGame);
    }

    // Moves to friendlist
    public void Options() {
        SceneLoader.Load(SceneLoader.Scene.Friendlist);
    }
    // Quits the app
    public void Quit() {
        Debug.Log("Quit pressed.");
        playerSettings.savePlayer();
        Application.Quit();
    }
}