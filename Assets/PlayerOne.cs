using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rb2d;
    private float speed = 2.0f;
    public float boundY = 0.5f;


    private BallController ballController; // Reference to BallController

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        // Get the BallController reference
        ballController = FindObjectOfType<BallController>();
        if (ballController == null)
        {
            Debug.LogError("BallController not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {


        float ySpeedFromBallController = ballController.YSpeed;
        Debug.Log("Yspeed: "+ ySpeedFromBallController);
        var vel = rb2d.velocity;
        vel.y = speed;

        rb2d.velocity = vel;
        var pos = transform.position;
        if (pos.y > boundY)
        {

            pos.y = boundY;
            speed = -speed;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
            speed = -speed;

        }
        transform.position = pos;
    }
}
