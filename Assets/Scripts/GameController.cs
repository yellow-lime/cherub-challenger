using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int highScore;
    public int initialSeconds;
    private int score = 0;

    public string gameOverSceneName;

    [Tooltip("Ref to the text with the 'time left' value.")]
    public Text textTime;
    public Text textScore;
    public Text textHighScore;


    [Tooltip("Seconds left in the current level.")]
    private int secondsLeft;

    private float timeToASecond;

    // Start is called before the first frame update
    void Start()
    {
        secondsLeft = initialSeconds;
        timeToASecond = 1;
        UpdateSecondsLeft();
        if(highScore == 0)
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeToASecond -= Time.deltaTime;
        if(timeToASecond < 0){
            timeToASecond = 1;
            UpdateSecondsLeft(-1);
        }

        if(Debug.isDebugBuild && Input.GetKeyDown(KeyCode.R)){
            RestartGame();
        }
    }

    void UpdateScore(int diff = 0)
    {
        score += diff;
        textScore.text = $"{score}";
    }

    void UpdateHighScore(int value)
    {
        highScore = value;
        textHighScore.text = $"{highScore}";
    }

    void UpdateSecondsLeft(int diff = 0)
    {
        secondsLeft += diff;
        textTime.text = $"{secondsLeft}";
    }

    void RestartGame()
    {
        if(score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
        }
        SceneManager.LoadScene(gameOverSceneName, LoadSceneMode.Additive);
    }
}
