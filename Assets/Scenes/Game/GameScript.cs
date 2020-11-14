using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
    public Button continueButton;
    
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(RequestRoutine(GlobalClass.API_URL + "/questions", ResponseCallback));
        btn1.onClick.AddListener(delegate { Clicked(0, btn1); });
        btn2.onClick.AddListener(delegate { Clicked(1, btn2); });
        btn3.onClick.AddListener(delegate { Clicked(2, btn3); });
        btn4.onClick.AddListener(delegate { Clicked(3, btn4); });
        continueButton.gameObject.SetActive(false);
        continueButton.onClick.AddListener(delegate { NextQuestion(); });
    }

    // Update is called once per frame
    void Update() {
    }

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

        myObject = JsonUtility.FromJson<QuestionSet>("{\"questions\":" + data + "}");
        Debug.Log(myObject.questions);
        foreach (var q in myObject.questions) {
            Debug.Log(q.question);
        }

        NextQuestion();
    }

    private void Clicked(int num, Button b) {
        Debug.Log(num);
        if (question.answers[num].Equals(question.correctAnswer)) {
            Debug.Log("JEE");
            var colors = b.colors;
            colors.selectedColor = Color.green;
            colors.disabledColor = Color.green;
            b.colors = colors;
        }
        else {
            Debug.Log("VAR");
            var colors = b.colors;
            colors.selectedColor = Color.red;
            colors.disabledColor = Color.red;
            b.colors = colors;

            if (btnText1.text.Equals(question.correctAnswer)) {
                var colorsA = btn1.colors;
                colorsA.normalColor = Color.green;
                colorsA.disabledColor = Color.green;
                btn1.colors = colorsA;
            } else if (btnText2.text.Equals(question.correctAnswer)) {
                var colorsA = btn2.colors;
                colorsA.normalColor = Color.green;
                colorsA.disabledColor = Color.green;
                btn2.colors = colorsA;
            } else if (btnText3.text.Equals(question.correctAnswer)) {
                var colorsA = btn3.colors;
                colorsA.normalColor = Color.green;
                colorsA.disabledColor = Color.green;
                btn3.colors = colorsA;
            } else if (btnText4.text.Equals(question.correctAnswer)) {
                var colorsA = btn4.colors;
                colorsA.normalColor = Color.green;
                colorsA.disabledColor = Color.green;
                btn4.colors = colorsA;
            }
        }
        
        setButtonsInteractable(false);

        continueButton.gameObject.SetActive(true);
    }

    private void NextQuestion() {
        continueButton.gameObject.SetActive(false);
        setButtonsInteractable(true);
        resetButtonColors();
        question = myObject.questions[Random.Range(0, 10)];
        questionText.text = question.question;
        btnText1.text = question.answers[0];
        btnText2.text = question.answers[1];
        btnText3.text = question.answers[2];
        btnText4.text = question.answers[3];
    }

    private void setButtonsInteractable(bool boolean) {
        btn1.interactable = boolean;
        btn2.interactable = boolean;
        btn3.interactable = boolean;
        btn4.interactable = boolean;
    }

    private void resetButtonColors() {
        var colors = btn1.colors;
        colors.normalColor = Color.white;
        colors.selectedColor = Color.white;
        colors.disabledColor = Color.white;
        btn1.colors = colors;
        btn2.colors = colors;
        btn3.colors = colors;
        btn4.colors = colors;
    }
    
}