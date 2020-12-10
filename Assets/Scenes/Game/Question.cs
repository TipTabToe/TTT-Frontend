using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
// Holds all information of a question
public class Question
{
    public long id;
    public string question;
    public string correctAnswer;
    public List<string> answers;
    public QuestionCategory category;
}
