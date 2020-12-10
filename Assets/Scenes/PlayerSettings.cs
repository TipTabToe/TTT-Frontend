using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Contains player's settings
public class PlayerSettings : MonoBehaviour {
    [SerializeField]
    private User user;
    
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
    
    // Loads the player when game starts
    public void Awake () {
        if (!PlayerPrefs.HasKey("player")) {
            Debug.Log("Create player");
            GlobalClass.player = new User();
            savePlayer();
        } else {
            Debug.Log("Loading player");
            GlobalClass.player = loadPlayer();
        }
    }

    // Saves the player's settings
    public void savePlayer() {
        PlayerPrefs.SetString("player", JsonUtility.ToJson(GlobalClass.player));
        PlayerPrefs.Save();
    }

    // Returns the loaded player
    public User loadPlayer() {
        GlobalClass.player = JsonUtility.FromJson<User>(PlayerPrefs.GetString("player"));
        Debug.Log(GlobalClass.player);
        return GlobalClass.player;
    }
    
    
}
