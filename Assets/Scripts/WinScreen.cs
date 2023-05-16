using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreDisplay;
    ScoreKeeper scoreKeeper;
    // Start is called before the first frame update
    void Awake()
    {
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
    }

    void Start()
    {
        ShowFinalScore();
    }

    public void ShowFinalScore() 
    {
        finalScoreDisplay.text = "Congratulations!\nYour final score was: " + scoreKeeper.GetTotalScore();
    }
}
