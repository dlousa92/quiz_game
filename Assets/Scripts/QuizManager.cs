using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI currentQuestionDisplay;
    QuestionSO currentQuestion;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    [Header("Sprites")]
    [SerializeField] Sprite defaultSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI currentScoreDisplay;
    ScoreKeeper scoreKeeper;
    bool didAnswerEarly = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Update()
    {
        float fillFractionValue = timer.GetFillFractionValue();
        timerImage.fillAmount = fillFractionValue;

        if (timer.GetLoadNextQuestionValue())
        {
            didAnswerEarly = false;
            GetNextQuestion();
            timer.SetLoadNextQuestionValue();
        } else if (!didAnswerEarly && !timer.isAnsweringQuestion)
        {
            CheckCorrectAnswer(-1);
            SetButtonState(false);
        }
    }

    void GetNextQuestion() 
    {
        if (questions.Count > 0)
        {
            GetRandomQuestion();
            DisplayQuestion();
            scoreKeeper.IncrementQuestionsSeen();
            SetButtonState(true);
            SetButtonDefaultSprites();
        } 
    }

    //Determines the question being pulled from our list
    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        questions.Remove(currentQuestion);
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
    //Checks if the answer is correct and changes ui sprite of correct answer button
    void CheckCorrectAnswer(int index)
    {
        Image buttonImage;
        int correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();

        if (index == correctAnswerIndex)
        {
            scoreKeeper.IncrementQuestionsAnsweredCorrectly();
            currentScoreDisplay.text = "Score: " + scoreKeeper.CalculateScore(timer.GetFillFractionValue());
            currentQuestionDisplay.text = "Yay! That's correct.";

            buttonImage = answerButtons[index].GetComponentInChildren<Image>();
            buttonImage.sprite = correctAnswerSprite;
            
        } else
        {
            buttonImage = answerButtons[correctAnswerIndex].GetComponentInChildren<Image>();
            currentQuestionDisplay.text = "Sorry the correct answer is: " + currentQuestion.GetAnswer(correctAnswerIndex) + ".";
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    //Handles all function calls once an answer is selected
    public void OnAnswerSelected(int index)
    {
        CheckCorrectAnswer(index);
        SetButtonState(false);
        didAnswerEarly = !didAnswerEarly;
        timer.CancelTimer();
    }

    //Disables and enables buttons in UI
    void SetButtonState(bool isInteractable)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponentInChildren<Button>();
            button.interactable = isInteractable;
        }
    }
}
