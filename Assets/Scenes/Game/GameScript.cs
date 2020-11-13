using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RequestRoutine("localhost:8080/api/questions", ResponseCallback));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Keep track of what we got back
    string recentData = "";

    // Web requests are typially done asynchronously, so Unity's web request system
    // returns a yield instruction while it waits for the response.
    //
    private IEnumerator RequestRoutine(string url, Action<string> callback = null)
    {
        // Using the static constructor
        var request = UnityWebRequest.Get(url);
 
        // Wait for the response and then get our data
        yield return request.SendWebRequest();
        var data = request.downloadHandler.text;
 
        // This isn't required, but I prefer to pass in a callback so that I can
        // act on the response data outside of this function
        if (callback != null)
            callback(data);
    }
 
    // Callback to act on our response data
    private void ResponseCallback(string data)
    {
        Debug.Log(data);
        recentData = data;
        
        var myObject = JsonUtility.FromJson<QuestionSet>("{\"questions\":" + data + "}");
        Debug.Log(myObject.questions);
        foreach (var q in myObject.questions) {
            Debug.Log(q.question);
        }
    }
}
