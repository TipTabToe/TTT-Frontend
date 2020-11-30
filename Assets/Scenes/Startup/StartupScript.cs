using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupScript : MonoBehaviour {
    // Start is called before the first frame update
    private float timer = 0;
    void Start() { }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        if (timer > 2) {
            SceneLoader.Load(SceneLoader.Scene.MainMenu);
        }
    }
}
