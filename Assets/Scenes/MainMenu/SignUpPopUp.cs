using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class SignUpPopUp : MonoBehaviour {
    public GameObject ui;
    public InputField username;
    public InputField password;

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

    public void Register() {
        ui.SetActive(!ui.activeSelf);
        if (!ui.activeSelf) {
            Time.timeScale = 1f;
        }
        
        Request("localhost:8080/api/users/login/register", username.text, password.text);
    }
    
    public void LogIn() {
        ui.SetActive(!ui.activeSelf);
        if (!ui.activeSelf) {
            Time.timeScale = 1f;
        }
        
        Request("localhost:8080/api/users/login/login", username.text, password.text);
        SceneLoader.Load(SceneLoader.Scene.PlayMenu);
    }

    public void Request(string requrl, string username, string password) {
        try {
            string url = requrl;

            var request = UnityWebRequest.Post(url, "");
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Accept", "text/csv");
            request.SetRequestHeader("username", username);
            request.SetRequestHeader("password", password);
            StartCoroutine(onResponse(request));
        }
        catch (Exception e) { Debug.Log("ERROR : " + e.Message); }
    }
    private IEnumerator onResponse(UnityWebRequest req) {
        yield return req.SendWebRequest();
        if (req.isError)
            Debug.Log("Network error has occured: " + req.GetResponseHeader(""));
        else
            Debug.Log("Success "+req.downloadHandler.text );
        byte[] results = req.downloadHandler.data;
        Debug.Log("Second Success");
        // Some code after success
    }
}