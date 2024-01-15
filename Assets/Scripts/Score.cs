using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] int scoreIncrease = 10;
    int score = 0;
    TMP_Text scoreText;

    void Awake() 
    {
        if (GetComponent<TMP_Text>() == null) { return; }

        scoreText = GetComponent<TMP_Text>();
    }

    void Start()
    {
        SetScoreText();
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void IncreaseScore()
    {
        score += scoreIncrease;
        SetScoreText();
    }

}
