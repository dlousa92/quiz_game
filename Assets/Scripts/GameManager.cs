using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    QuizManager quizManager;
    WinScreen winScreen;
    // Start is called before the first frame update

    void Awake()
    {
        quizManager = FindAnyObjectByType<QuizManager>();
        winScreen = FindAnyObjectByType<WinScreen>();
    }
    void Start()
    {
        quizManager.gameObject.SetActive(true);
        winScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (quizManager.GetCompletedGameStatus())
        {
            quizManager.gameObject.SetActive(false);
            winScreen.gameObject.SetActive(true);
        }
    }

    public void OnReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
