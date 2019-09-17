using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public Animator ani;
    private SpriteRenderer sr;
    public Rigidbody2D body;
    public Sprite rightSprite, leftSprite, upSprite;
    public Text countText;
    enum AniDirection { UP, LEFT, RIGHT };
    AniDirection directionFacing;
    private int count;
    //public float gameTimer = 300.0f;

    //public Text timerText;
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        ani = gameObject.GetComponent<Animator>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        directionFacing = AniDirection.RIGHT;
        //timerText.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        SetDirection();
        Move();
        //gameTimer -= Time.deltaTime;

        //if (gameTimer > 0)
        //{
         //   timerText.text = "Timer:" + gameTimer.ToString();
        //}
        //else
        //{
           // timerText.text = "Timer: 0";
       // }
    }

   // public void DecreaseTimer()
   //{
   //     gameTimer -= 10.0f;
   // }


    void SetDirection()
    {
        switch (directionFacing)
        {
            case AniDirection.UP:
                sr.sprite = upSprite;
                break;
            case AniDirection.LEFT:
                sr.sprite = leftSprite;
                break;
            case AniDirection.RIGHT:
                sr.sprite = rightSprite;
                break;
        }

    }

    void Move()
    {
        ani.enabled = true;
        if (Input.GetKey(KeyCode.W))
        {
            body.transform.Translate(Vector2.up * 0.1f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            directionFacing = AniDirection.LEFT;
            ani.Play("New Animation"); body.transform.Translate(Vector2.left * 0.1f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            directionFacing = AniDirection.RIGHT;
            ani.Play("Right Walk"); body.transform.Translate(Vector2.right * 0.1f);
        }
        else { ani.enabled = false; }

    }




}
