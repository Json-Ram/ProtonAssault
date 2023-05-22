using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;
    public void IncreaseScore(int increaseAmount)
    {
        score += increaseAmount;
        Debug.Log($"Your score is: {score}");
    }
}
