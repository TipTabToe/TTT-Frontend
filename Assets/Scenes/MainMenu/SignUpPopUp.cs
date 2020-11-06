using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine;

public class SignUpPopUp : MonoBehaviour {
    public GameObject ui;

    // Start is called before the first frame update
    void Start() {
        ui.SetActive(!ui.activeSelf);
    }

    // Update is called once per frame
    void Update() {
    }

    public void Open() {
        ui.SetActive(!ui.activeSelf);
        if (ui.activeSelf) {
            Time.timeScale = 0f;
        }
    }

    public void Close() {
        ui.SetActive(!ui.activeSelf);
        if (!ui.activeSelf) {
            Time.timeScale = 1f;
        }
    }
    
    public void CloseAndPlay() {
        ui.SetActive(!ui.activeSelf);
        if (!ui.activeSelf) {
            Time.timeScale = 1f;
        }
        
        SceneLoader.Load(SceneLoader.Scene.PlayMenu);
    }
}