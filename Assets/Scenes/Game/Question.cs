using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Question
{
    public long id;
    public string question;
    public string correctAnswer;
    public List<string> answers;
    public QuestionCategory category;
}
