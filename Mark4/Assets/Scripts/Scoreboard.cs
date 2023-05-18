using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Scoreboard : MonoBehaviour
{
    int score;
    TMP_Text scoreText;
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "0";
    }
    public void IncreaseScore(int val)
    {
        score += val;
        scoreText.text = score.ToString();
    }
}
