using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {
    
    SignUpPopUp popupWindow;
    GameObject gameController;
    private PlayerSettings playerSettings;

    void Start () {
        gameController = GameObject.Find("GameController");
        popupWindow = gameController.GetComponent<SignUpPopUp> ();
        playerSettings = gameController.GetComponent<PlayerSettings>();
    }
    
    public void Play() {
        SceneLoader.Load(SceneLoader.Scene.CreateGame);
    }

    public void Options() {
        SceneLoader.Load(SceneLoader.Scene.Friendlist);
    }
    
    public void Quit() {
        Debug.Log("Quit pressed.");
        playerSettings.savePlayer();
        Application.Quit();
    }
}