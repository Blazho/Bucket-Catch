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
    //Spawner script from spawn's gameobject
    public Spawner Spawner { get; set; }
    //How many points needed to reduce time between spawns
    public int pointsToSpeed { get; set; } = 10;


    void Awake()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
        Spawner = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Spawner>();
        score = 0;
        display();
        ConsecutiveFouls = 0;
        totalNegativePoints = 0;

    }

    public void AddPoint(int a)
    {
        score+= a;
        if (score == pointsToSpeed && Spawner.TimeBetweenSpawns == 2)
        {
            Spawner.incrementFreq();
            Debug.Log("Frequency incresed to: " + Spawner.TimeBetweenSpawns);
        }
        ConsecutiveFouls = 0;
        display();
    }

    public void RemovePoint()
    {
        score--;
        ConsecutiveFouls++;
        totalNegativePoints++;
        Debug.Log("NegativePoints: " + totalNegativePoints + " Fouls: " + ConsecutiveFouls);
        display();
        if (ConsecutiveFouls == 3 || totalNegativePoints >= 10)
        {
            //scoreText.text = "You lose";
        }
    }

    private void display()
    {
        scoreText.text = $"Score: {score}";
    }
}
