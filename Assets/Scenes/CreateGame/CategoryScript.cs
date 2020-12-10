using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

// Holds buttons for categories and randomizes the chosen category
public class CategoryScript : MonoBehaviour {
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;

    private void Start() {
        Invoke("ShowSelectedCategory", 1);
    }

    // Turn the selected category button green
    public void ShowSelectedCategory() {
        var colors = btn1.colors;
        colors.normalColor = Color.green;
        int random = Random.Range(0, 4);

        if (random == 0) {
            btn1.colors = colors;
            GlobalClass.category = 2;
            // "Transportation"
        } else if (random == 1) {
            btn2.colors = colors;
            GlobalClass.category = 1;
            // "Consumption"
        } else if (random == 2) {
            btn3.colors = colors;
            GlobalClass.category = 3;
            // "Food"
        } else if (random == 3) {
            btn4.colors = colors;
            GlobalClass.category = 4;
            // "Waste"
        }
        
        Invoke("PlayGame", 2);
    }

    // Automatically loads the next scene when chosen category has been shown
    private void PlayGame() {
        SceneLoader.Load(SceneLoader.Scene.Game);
    }
    
}