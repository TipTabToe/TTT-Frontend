using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour {
    [SerializeField]
    private User user;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
    
    public void Awake () {
        /**
         * Check if the PlayerPrefs has a cached setting for the “player” key.
         * If there is no value there, it creates a key-value pair for the player key with a value of 1.
         * This will be run the first time the player runs the game.
         * The value of 1 is used as true and 0 as false, because you cannot store a Boolean.
         */
        if (!PlayerPrefs.HasKey("player")) {
            PlayerPrefs.SetInt("player", 1);
            // save something else?
            PlayerPrefs.Save ();
        } 
        /**
         * This checks the “player” key saved in the PlayerPrefs.
         * If the value is set to 1, the player has previously registered or signed in. Otherwise, it opens the pop up.
         */
        else {
            if (PlayerPrefs.GetInt ("player") == 0) {
                // open pop up
            }
            else {
                // go to game
            }
        }
    }
}
