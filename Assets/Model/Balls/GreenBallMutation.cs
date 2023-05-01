using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBallMutation : Ball
{
    public float speedMultiplier { get; private set; }
    private bool speedUp;

    private void Awake()
    {
        speedMultiplier = Random.Range(2f, 3f);
        speedUp = false;
    }

    private void FixedUpdate()
    {
        if(!speedUp && gameObject.transform.position.z < -170 && gameObject.transform.position.z > -240)
        {
            speed *= speedMultiplier;
            speedUp = true;
        }
        gameObject.transform.Translate(transform.forward * -speed);
        if (gameObject.transform.position.y < -0.4)
        {
            Destroy(gameObject);
        }
    }
}
