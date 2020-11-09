using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void CreateGame() {
        SceneLoader.Load(SceneLoader.Scene.Lobby);
    }
    
    public void Back() {
        SceneLoader.Load(SceneLoader.Scene.MainMenu);
    }
}
