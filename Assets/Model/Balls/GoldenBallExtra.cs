using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoldenBallExtra : Ball
{

    private MeshRenderer playerMesh;
    private playerMovement playerClass;
    private GameObject player;
    private PurpleTimer playerTimer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMesh = player.GetComponent<MeshRenderer>();
        playerClass = player.GetComponent<playerMovement>();
        playerTimer = GameObject.FindGameObjectWithTag("PurpleTimer").GetComponent<PurpleTimer>();
    }

    private void FixedUpdate()
    {
        gameObject.transform.Translate(transform.forward * -speed);
        if (gameObject.transform.position.y < -0.4)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(player.transform.localScale.x < 3.5f)
            {
                player.transform.localScale += new Vector3(2.5f, 0);
            }
            playerMesh.material.color = new Color(1, 0, 1, 1);
            playerClass.TimePurple = Time.time;
            playerClass.isPurple = true;
            playerTimer.startTimer();

        }
    }
}
