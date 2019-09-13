using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    float speed;

    public Rigidbody2D body;
    public bool detected;
    public int points;
    public Text score;

    public Animator ani;

    private string directionFacing;
    const string UP = "up";
    const string DOWN = "down";
    const string LEFT = "left";
    const string RIGHT = "right";

    public Sprite upSprite, downSprite, rightSprite, leftSprite;
    private SpriteRenderer sr;
    private Vector2 lookVector;

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        ani = gameObject.GetComponent<Animator>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        speed = 2.0f;
        points = 0;
        detected = false;
        directionFacing = UP;
        lookVector = Vector2.up;
    }

    void Update()
    {
        SetDirection();
        Move();
        Raycast();
        SetText();
    }

    void SetDirection()
    {
        switch (directionFacing)
        {
            case LEFT:
                // change to left facing sprite
                sr.sprite = leftSprite;
                break;
            case RIGHT:
                // change to right facing sprite
                sr.sprite = rightSprite;
                break;
            case UP:
                // change to up facing sprite
                sr.sprite = upSprite;
                break;
            case DOWN:
                // down facing sprite
                sr.sprite = downSprite;
                break;
        }
    }

    // moves player around
    void Move()
    {
        ani.enabled = true;
        if (Input.GetKey(KeyCode.A))
        { // move left
            transform.position += Vector3.left * speed * Time.deltaTime;
            ani.Play("Walk_Left");
            directionFacing = LEFT;
            lookVector = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D))
        { // move right
            transform.position += Vector3.right * speed * Time.deltaTime;
            ani.Play("Walk_Right");
            directionFacing = RIGHT;
            lookVector = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.W))
        { // move up
            transform.position += Vector3.up * speed * Time.deltaTime;
            ani.Play("Walk_Up");
            directionFacing = UP;
            lookVector = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        { // move down
            transform.position += Vector3.down * speed * Time.deltaTime;
            ani.Play("Walk_Down");
            directionFacing = DOWN;
            lookVector = Vector2.down;
        }
        else
        {
            ani.enabled = false;
        }
    }

    // sets UI score text
    void SetText()
    {
        score.text = "Score: " + points;
    }

    void Raycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lookVector);
        if (hit.collider != null && hit.collider.tag == "NPC" && hit.distance < 3.0f)
        {
            print("it's a hit");
            hit.transform.SendMessage("HitByRay");
        }

    }
}
