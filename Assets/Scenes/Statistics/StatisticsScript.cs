﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneLoader.Load(SceneLoader.Scene.MainMenu);
        }
    }
    
    public void BackToMainMenu() {
        SceneLoader.Load(SceneLoader.Scene.MainMenu);
    }
}
