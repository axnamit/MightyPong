using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float speed = 6.0f;
    public float boundY = 3.3f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var vel = rb2d.velocity;

        if (Input.GetKey(KeyCode.W))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }

        rb2d.velocity = vel;
        var pos = transform.position;
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;
    }
}
