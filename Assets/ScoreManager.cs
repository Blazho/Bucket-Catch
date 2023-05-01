using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score { get; private set; }

    public int ConsecutiveFouls { get; private set; }

    public int totalNegativePoints { get; private set; }


    void Awake()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
        score = 0;
        display();
        ConsecutiveFouls = 0;
        totalNegativePoints = 0;

    }

    public void AddPoint(int a)
    {
        score+= a;
        
        ConsecutiveFouls = 0;
        display();
    }

    public void RemovePoint()
    {
        score--;
        ConsecutiveFouls++;
        totalNegativePoints++;
        Debug.Log("Fouls: " + ConsecutiveFouls);
        Debug.Log("NegativePoints: " + totalNegativePoints);
        display();
        if (ConsecutiveFouls == 3 || totalNegativePoints >= 10)
        {
            scoreText.text = "You lose";
        }
    }

    private void display()
    {
        scoreText.text = $"Score: {score}";
    }
}
