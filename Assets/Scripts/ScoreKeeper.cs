using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    // Start is called before the first frame update
    int questionsSeen;
    int questionsAnsweredCorrectly;
    int totalScore;
    [SerializeField] int timerMultiplier;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetQuestionsSeen()
    {
        return questionsSeen;
    }

    public void IncrementQuestionsSeen()
    {
        questionsSeen++;
    }

    public int GetQuestionsAnsweredCorrectly()
    {
        return questionsAnsweredCorrectly;
    }

    public void IncrementQuestionsAnsweredCorrectly()
    {
        questionsAnsweredCorrectly++;
    }

    public int CalculateScore(float timerRemainder)
    {
        totalScore = Mathf.RoundToInt(totalScore + 100 + (timerRemainder * timerMultiplier));

        return totalScore;
    }

    public int GetTotalScore()
    {
        return totalScore;
    }
}
