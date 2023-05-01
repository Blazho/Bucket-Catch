using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallMutation : Ball
{
    public bool Jumped { get; private set; }
    public int Movment { get; private set; }

    public Vector3 Direction { get; private set; }
    void Awake()
    {
        Jumped = false;
        Movment = 8;
        Direction = transform.right * getLine();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        if (!Jumped && gameObject.transform.position.z < -235 && gameObject.transform.position.z > -240 )
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Direction, ForceMode.Impulse);
            Jumped = true;
        }
        gameObject.transform.Translate(transform.forward * -speed);
        if (gameObject.transform.position.y < -0.4)
        {
            Destroy(gameObject);
        }
    }
    private int getLine()
    {
        if(gameObject.transform.position.x == 0)
        {
            int side = Random.Range(0, 1);
            return (side == 0) ? -1 * Movment : 1 * Movment;
            
        }
        return gameObject.transform.position.x > 0 ? -Movment : Movment;
    }
}
