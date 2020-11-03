using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoaderCallback : MonoBehaviour {
    private bool firstFrame = true;
    public TextMeshProUGUI loadingText;
    private string loading = "LOADING";
    private string[] dots =  {"", ".", "..", "..."};
    private int selector = 0;
    private float timer = 0.0f;

    // Update is called once per frame
    void Update() {
        /*
        if (!firstFrame) return;
        firstFrame = false;
        SceneLoader.LoaderCallback();
        */
        timer += Time.deltaTime;
        if (timer > 4) {
            timer -= 4;
        }

        if (selector != (int)timer) {
            selector = (int) timer;
            loadingText.text = loading + dots[selector];
        }
        
        Debug.Log(timer);
    }
}