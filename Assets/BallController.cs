using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{


    private int playerOneScore = 0;
    private int playerTwoScore = 0;
    private Rigidbody2D rb2d;
    private float xspeed = 4.2f;
    private float yspeed = 2.2f;
    private float boundY = 4.0f;
    private float boundX = 6.3f;
    private bool isGameOver = false;
    public Font customFont;

    public float YSpeed
    {
        get { return yspeed; }
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    void OnGUI()
    {


        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 44;
        style.normal.textColor = Color.white;
        style.font = customFont;
        GUI.Label(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 200, 100, 50), "" + playerOneScore, style);
        GUI.Label(new Rect(Screen.width / 2 + 160, Screen.height / 2 - 200, 100, 50), "" + playerTwoScore, style);

        if (isGameOver)
        {
            GUI.Label(new Rect(Screen.width / 2 - 140, Screen.height / 2 - 25, 450, 50), "Game Over", style);
            style.fontSize = 34;

            GUI.Label(new Rect(Screen.width / 2 - 140, Screen.height / 2 - 100, 450, 50), "Player " + (playerOneScore > playerTwoScore ? "One Win !" : "Two Win !"), style);


            GUIStyle customStyle = new GUIStyle(GUI.skin.button);
            customStyle.font = customFont;
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 45, 100, 50), "Restart",customStyle))
            {
                RePlayGame();
                playerOneScore = 0;
                playerTwoScore = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;
        vel.y = yspeed;
        vel.x = xspeed;
        rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.y > boundY)
        {
            pos.y = boundY;
            yspeed = -yspeed;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
            yspeed = -yspeed;

        }
        if (pos.x > boundX)
        {
            pos.x = boundX;
            xspeed = -xspeed;
        }
        else if (pos.x < -boundX)
        {
            pos.x = -boundX;
            xspeed = -xspeed;

        }
        transform.position = pos;

        if (playerOneScore >= 10 || playerTwoScore >= 10)
        {
            isGameOver = true;
            Time.timeScale = 0f;
        }

    }



    void RePlayGame()
    {
        transform.position = Vector2.zero;
        rb2d.velocity = Vector2.zero;

        isGameOver = false;

        Time.timeScale = 1f;

        xspeed = -xspeed;
        yspeed = -yspeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            xspeed = -xspeed;
        }

        if (collision.gameObject.CompareTag("wallOne") || collision.gameObject.CompareTag("wallTwo"))
        {

            if (collision.gameObject.CompareTag("wallOne"))
            {
                playerTwoScore++;
            }
            else
            {
                playerOneScore++;
            }

            RePlayGame();


        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player1") && collision.gameObject.CompareTag("Player2"))
        {
            xspeed = -xspeed;
        }

        if (collision.gameObject.CompareTag("wallOne") || collision.gameObject.CompareTag("wallTwo"))
        {

            if (collision.gameObject.CompareTag("wallOne"))
            {
                playerTwoScore++;
            }
            else
            {
                playerOneScore++;
            }

            RePlayGame();


        }
    }



}
