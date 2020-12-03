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
    public Image categoryImage;
    private int cycle = 0;
    private int points = 0;
    private int amountOfQuestions = 6;
    private List <int> shuffledQuestions = new List<int>(4);

    // Start is called before the first frame update
    void Start() {
        shuffleQuestions();
        StartCoroutine(RequestRoutine(GlobalClass.API_URL + "/questions", ResponseCallback));
        btn1.onClick.AddListener(delegate { Clicked(shuffledQuestions[0], btn1); });
        btn2.onClick.AddListener(delegate { Clicked(shuffledQuestions[1], btn2); });
        btn3.onClick.AddListener(delegate { Clicked(shuffledQuestions[2], btn3); });
        btn4.onClick.AddListener(delegate { Clicked(shuffledQuestions[3], btn4); });
        /* continueButton.gameObject.SetActive(false);
        scoreButton.gameObject.SetActive(false);
        continueButton.onClick.AddListener(delegate { NextQuestion(); });
        scoreButton.onClick.AddListener(delegate { SeeScore(); }); */
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
        TimerScript.answered = true;
        Debug.Log("Num" + num);
        Debug.Log("Questions answers num" + question.answers[num]);
        Debug.Log("Oikea vastaus" + question.correctAnswer);
        if (question.answers[num].Equals(question.correctAnswer)) {
            Debug.Log("JEE");
            var colors = b.colors;
            colors.selectedColor = Color.green;
            colors.disabledColor = Color.green;
            b.colors = colors;
            points++;
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

        cycle++;

        if (cycle < 5) {
            // continueButton.gameObject.SetActive(true);
            Invoke("NextQuestion", 4);
        }
        else {
            //scoreButton.gameObject.SetActive(true);
            Invoke("SeeScore", 4);
            GlobalClass.player.points = points;
        }
    }

    public void TimeRunsOut() {
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
        
        setButtonsInteractable(false);

        cycle++;

        if (cycle < 5) {
            // continueButton.gameObject.SetActive(true);
            Invoke("NextQuestion", 3);
        }
        else {
            //scoreButton.gameObject.SetActive(true);
            Invoke("SeeScore", 3);
            GlobalClass.player.points = points;
        }
    }

    public void NextQuestion() {
        // continueButton.gameObject.SetActive(false);
        setButtonsInteractable(true);
        resetButtonColors();
        question = myObject.questions[Random.Range(0, amountOfQuestions)];
        questionText.text = question.question;

        btnText1.text = question.answers[shuffledQuestions[0]];
        btnText2.text = question.answers[shuffledQuestions[1]];
        btnText3.text = question.answers[shuffledQuestions[2]];
        btnText4.text = question.answers[shuffledQuestions[3]];
        TimerScript.ResetTimer();
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

    private void SeeScore() {
        SceneLoader.Load(SceneLoader.Scene.Score);
        // SceneLoader.Load(SceneLoader.Scene.MainMenu);
    }

    private void shuffleQuestions() {
        shuffledQuestions.Clear();
        int i = 0;
        while (i < 4) {
            int random = Random.Range(0, 4);
            if (!shuffledQuestions.Contains(random)) {
                shuffledQuestions.Add(random);
                i++;
            }
        }
    }
}