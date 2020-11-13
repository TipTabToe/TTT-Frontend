using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {
    public TMP_Text questionText;
    private QuestionSet myObject;
    private Question question;
    public TMP_Text btnText1;
    public TMP_Text btnText2;
    public TMP_Text btnText3;
    public TMP_Text btnText4;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;


    // Start is called before the first frame update
    void Start() {
        StartCoroutine(RequestRoutine(GlobalClass.API_URL + "/questions", ResponseCallback));
        btn1.onClick.AddListener(delegate { Clicked(0, btn1); });
        btn2.onClick.AddListener(delegate { Clicked(1, btn2); });
        btn3.onClick.AddListener(delegate { Clicked(2, btn3); });
        btn4.onClick.AddListener(delegate { Clicked(3, btn4); });
    }

    // Update is called once per frame
    void Update() {
    }

    // Keep track of what we got back
    string recentData = "";

    // Web requests are typially done asynchronously, so Unity's web request system
    // returns a yield instruction while it waits for the response.
    //
    private IEnumerator RequestRoutine(string url, Action<string> callback = null) {
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
    private void ResponseCallback(string data) {
        Debug.Log(data);
        recentData = data;

        myObject = JsonUtility.FromJson<QuestionSet>("{\"questions\":" + data + "}");
        Debug.Log(myObject.questions);
        foreach (var q in myObject.questions) {
            Debug.Log(q.question);
        }

        question = myObject.questions[1];
        questionText.text = question.question;
        btnText1.text = question.answers[0];
        btnText2.text = question.answers[1];
        btnText3.text = question.answers[2];
        btnText4.text = question.answers[3];
    }

    private void Clicked(int num, Button b) {
        Debug.Log(num);
        if (question.answers[num].Equals(question.correctAnswer)) {
            Debug.Log("JEE");
            var colors = b.colors;
            colors.selectedColor = Color.green;
            b.colors = colors;
        }
        else {
            Debug.Log("VAR");
        }
        
        
    }
}