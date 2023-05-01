using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float TimePurple { get; set; }
    public bool isPurple;
    public float speed = 0.2f;
    ScoreManager scoreManager;
    MeshRenderer mesh;
    private float width;
    private GameObject playerBucket;
    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        TimePurple = Time.time;
        isPurple = false;
        Debug.Log("Time purple = " + TimePurple);
        Debug.Log(Time.time + 10);

    }
    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        playerBucket = GameObject.FindGameObjectWithTag("Player");
        mesh = gameObject.GetComponent<MeshRenderer>();

        mesh.material.color = Color.red;
    }
    void FixedUpdate()
    {
        if(isPurple && TimePurple + 10 <= Time.time )
        {
            shrinkPlayer();
        }
        if (Input.touchCount > 0)
        {
            int lastTouch = Input.touchCount - 1;
            Touch touch = Input.GetTouch(lastTouch);
            if (touch.position.x > width && gameObject.transform.position.x < 4.5)
            {
                moveRight();
            }
            if(touch.position.x < width && gameObject.transform.position.x > -4.5)
            {
                moveLeft();
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow) && gameObject.transform.position.x > -4.5)
        {
            moveLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow) && gameObject.transform.position.x < 4.5)
        {
            moveRight();
        }
    }
    private void moveLeft()
    {
        gameObject.transform.Translate(transform.right * -speed );
    }
    private void moveRight()
    {
        gameObject.transform.Translate(transform.right * speed );
    }
    private void shrinkPlayer()
    {
        gameObject.transform.localScale = Vector3.one;
        gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        isPurple = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        string ballTag = collision.gameObject.tag;
        Color playerColor = mesh.material.color;

        Color ballColor = getColorByTag(ballTag);

        if(playerColor == ballColor)
        {
            scoreManager.AddPoint(1);
            swapColors(ballColor);
        }//Purple
        else if(playerColor == new Color(1, 0, 1, 1))
        {
            scoreManager.AddPoint(1);
        }//!Golden
        else if(ballColor != new Color(1, 1, 0, 1))
        {
            scoreManager.RemovePoint();
        }
        
        Destroy(collision.gameObject);

    }
    private Color getColorByTag(string tag)
    {
        switch (tag)
        {
            case "BlueBall":
                return Color.blue;
            case "RedBall":
                return Color.red;
            case "GreenBall":
                return Color.green;
            case "GoldenBall":
                return new Color(1, 1, 0, 1);
            default:
                return new Color(1, 0, 1, 1);
        }
    }

    // R->B->G
     void swapColors(Color targetColor)
    {
        if(targetColor ==  Color.red)
        {
            mesh.material.color = Color.blue;

        }else if(targetColor == Color.blue)
        {
            mesh.material.color = Color.green;

        }else if(targetColor== Color.green)
        {
            mesh.material.color = Color.red;
        }
        

    }
}
