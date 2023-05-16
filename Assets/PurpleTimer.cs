using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PurpleTimer : MonoBehaviour
{
    public float TimeLeft { get; set; } = 10;
    public bool TimerOn { get; set; } = false;
    public TextMeshPro TimerMesh { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        TimerMesh = GameObject.FindGameObjectWithTag("PurpleTimer").GetComponent<TextMeshPro>();
    }


    private void FixedUpdate()
    {
        if(TimerOn)
        {
            if (TimeLeft >= 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer();
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;
                TimerMesh.text = "";
            }
        }
        
    }

    void updateTimer()
    {
        TimerMesh.text = string.Format("{00}",Mathf.Round(TimeLeft));
    }

    public void startTimer()
    {
        TimeLeft = 10;
        TimerOn = true;
    }
}
