using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BowlingManager : MonoBehaviour
{
    public static BowlingManager Instance;
    private int score = 0;
    public Text scoreText;

    private void Awake()
    {
       if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
       else //Weird Auto Spacing Might cause Problems
        {
            Destroy(gameObject);
        }
        
    }

    public void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score + "/10";
        Debug.Log("Current Score: " + score + "/10");
    }
}