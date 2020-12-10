using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlistScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Makes phones back button go back
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneLoader.Load(SceneLoader.Scene.MainMenu);
        }
    }
    
    // Makes back button direct to MainMenu
    public void BackToMainMenu() {
        SceneLoader.Load(SceneLoader.Scene.MainMenu);
    }
}
