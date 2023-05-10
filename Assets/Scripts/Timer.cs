using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToAnswerQuestion = 30f;
    [SerializeField] float timeInBetweenQuestion = 5f;
    public bool isAnsweringQuestion = false;
    float timerValue;

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
       timerValue -= Time.deltaTime;

        if (timerValue <= 0 && isAnsweringQuestion)
        {
            timerValue = timeInBetweenQuestion;
            isAnsweringQuestion = !isAnsweringQuestion;

        } else if (timerValue <= 0 && !isAnsweringQuestion)
        {
            timerValue = timeToAnswerQuestion;
            isAnsweringQuestion = !isAnsweringQuestion;
        }

        Debug.Log(timerValue); 
    }
}
