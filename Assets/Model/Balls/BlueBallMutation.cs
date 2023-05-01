using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBallMutation : Ball
{
    public bool Teleported { get; private set; }
    public int Movment { get; private set; }

    private void Awake()
    {
        Teleported = false;
        Movment = gameObject.transform.position.x != 0 ? getLine() : 0;
    }

    private void FixedUpdate()
    {
        if(!Teleported && gameObject.transform.position.z < -235 && gameObject.transform.position.z > -240)
        {
            gameObject.transform.Translate(transform.right * Movment);
            Teleported = true;
        }
        gameObject.transform.Translate(transform.forward * -speed);
        if (gameObject.transform.position.y < -0.4)
        {
            Destroy(gameObject);
        }
    }
    private int getLine()
    {
        return gameObject.transform.position.x != 0 && gameObject.transform.position.x > 0 ? -8 : 8;
    }
}
