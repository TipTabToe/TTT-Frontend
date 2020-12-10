using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Calls back the loader
public class LoaderCallback : MonoBehaviour {
    private bool firstFrame = true;
    public TextMeshProUGUI loadingText;
    private string loading = "LOADING";
    private string[] dots =  {"", ".", "..", "..."};
    private int selector = 0;
    private float timer = 0.0f;

    // Shows the loading "animation"
    void Update() {

        timer += Time.deltaTime;
        if (timer > 4) {
            timer -= 4;
        }

        if (selector != (int)timer) {
            selector = (int) timer;
            loadingText.text = loading + dots[selector];
        }
        // Debug.Log(timer);
        if (!firstFrame) return;
        firstFrame = false;
        
        Invoke("callCallbackMethod", 2);
        // SceneLoader.LoaderCallback();
    }

    // Calls the callback method
    private void callCallbackMethod() {
        SceneLoader.LoaderCallback();
    }
}