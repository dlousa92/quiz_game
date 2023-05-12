using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToAnswerQuestion = 30f;
    [SerializeField] float timeInBetweenQuestion = 5f;
    public bool isAnsweringQuestion = false;
    bool loadNextQuestion = false;
    float fillFraction;
    float timerValue;

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
       timerValue -= Time.deltaTime;

        if (timerValue > 0) {
            if (isAnsweringQuestion)
            {
                fillFraction = timerValue / timeToAnswerQuestion;
            } else 
            {
                fillFraction = timerValue / timeInBetweenQuestion;
            }
        } else if (timerValue <= 0 && isAnsweringQuestion)
        {
            timerValue = timeInBetweenQuestion;
            isAnsweringQuestion = !isAnsweringQuestion;

        } else if (timerValue <= 0 && !isAnsweringQuestion)
        {
            timerValue = timeToAnswerQuestion;
            isAnsweringQuestion = !isAnsweringQuestion;
            loadNextQuestion = true;
        }
    }

    public float GetFillFractionValue()
    {
        return fillFraction;
    }

    public bool GetLoadNextQuestionValue()
    {
        return loadNextQuestion;
    }

    public void SetLoadNextQuestionValue()
    {
        loadNextQuestion = !loadNextQuestion;
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }
}
