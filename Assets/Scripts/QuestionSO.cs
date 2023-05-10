using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(1, 6)]
    [SerializeField] string question = "Sample";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex;
    public string GetQuestion()
    {
        return question;
    }

    public void SetQuestion(string newQuestion)
    {
        question = newQuestion;
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }
}
