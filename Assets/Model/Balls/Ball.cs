using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;

    void Start()
    {

        speed = 1;
    }

    private void FixedUpdate()
    {
        gameObject.transform.Translate(transform.forward * -speed);
        if (gameObject.transform.position.y < -0.4)
        {
            Destroy(gameObject);
        }
    }
}
