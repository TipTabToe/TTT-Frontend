using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class SignUpPopUp : MonoBehaviour {
    public GameObject ui;
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    private User user;

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
        
        StartCoroutine(RequestRoutine(GlobalClass.API_URL + "/users/register", usernameField.text, passwordField.text, ResponseCallback));
        // Request(GlobalClass.API_URL + "/users/register", usernameField.text, passwordField.text);
    }
    
    public void LogIn() {
        ui.SetActive(!ui.activeSelf);
        if (!ui.activeSelf) {
            Time.timeScale = 1f;
        }
        
        //Request(GlobalClass.API_URL + "/users/login", usernameField.text, passwordField.text);
        SceneLoader.Load(SceneLoader.Scene.PlayMenu);
    }

    /*
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
        Debug.Log(results);
        Debug.Log("Second Success");
    }
    */
    
    private IEnumerator RequestRoutine(string url, string username, string password, Action<string> callback = null) {
        var request = UnityWebRequest.Post(url, "");
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Accept", "application/json");
        request.SetRequestHeader("username", username);
        request.SetRequestHeader("password", password);
        
        // Wait for the response and then get our data
        yield return request.SendWebRequest();
        
        if (request.isError)
            Debug.Log("Network error has occured: " + request.GetResponseHeader(""));
        else
            Debug.Log("Success "+request.downloadHandler.text );
        
        var data = request.downloadHandler.text; // tai data
        
        Debug.Log(request.responseCode);

        // This isn't required, but I prefer to pass in a callback so that I can
        // act on the response data outside of this function
        if (callback != null)
            callback(data);
    }

    // Callback to act on our response data
    private void ResponseCallback(string data) {
        Debug.Log(data);
        
        user = JsonUtility.FromJson<User>(data);
        user.password = passwordField.text;
        Debug.Log(user);
    }

}