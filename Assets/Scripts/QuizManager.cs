using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentQuestionDisplay;
    [SerializeField] QuestionSO currentQuestion;
    [SerializeField] GameObject[] answerButtons;
    [SerializeField] Sprite defaultSprite;
    [SerializeField] Sprite correctAnswerSprite;

    // Start is called before the first frame update
    void Start()
    {
        GetNextQuestion();
    }

    void GetNextQuestion() 
    {
        DisplayQuestion();
        SetButtonState(true);
        SetButtonDefaultSprites();
    }

    //Displays the current question in the UI
    void DisplayQuestion()
    {
        currentQuestionDisplay.text = currentQuestion.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }
    void SetButtonDefaultSprites()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponentInChildren<Image>();
            buttonImage.sprite = defaultSprite;
        }
    }
    // Checks if the answer is correct and changes ui sprite of correct answer button
    public void OnAnswerSelected(int index)
    {
        Image buttonImage;

        
        if (index == currentQuestion.GetCorrectAnswerIndex())
        {
            buttonImage = answerButtons[index].GetComponentInChildren<Image>();

            currentQuestionDisplay.text = "Yay!";
            buttonImage.sprite = correctAnswerSprite;
        } else
        {
            int correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
            buttonImage = answerButtons[correctAnswerIndex].GetComponentInChildren<Image>();

            currentQuestionDisplay.text = "Sorry the correct answer is: " + currentQuestion.GetAnswer(correctAnswerIndex);
            buttonImage.sprite = correctAnswerSprite;
        }

        SetButtonState(false);
    }

    //disables and enables buttons in UI
    void SetButtonState(bool isInteractable)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponentInChildren<Button>();
            button.interactable = isInteractable;
        }
    }
}
