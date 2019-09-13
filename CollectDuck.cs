using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectDuck : MonoBehaviour
{
    public Text CountText;
    private int count;
    MainScript timerScript;
    public int DUCKPOINTS { get; private set; }

    // Use this for initialization
    void Start()
    {
        count = 0;
        SetCountText();
        timerScript = FindObjectOfType<MainScript>();
    }

    // Update is called once per frame
    void Update()
    {
        SetCountText();
        //EndGame();
    }
    void SetCountText()
    {
        CountText.text = "Ducks Collected \n" + count.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DUCKPOINT"))
        {

            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }



    }

    // void EndGame()
    // {
    // at end game
    //if (timerScript.gameTimer < 0)
    //  {

    // very bad
    // if (count >= 0 && count <= 3) Application.LoadLevel("Ending1");

    // call scene

    // bad
    //else if (count >= 4 && count <= 15) Application.LoadLevel("Ending2");

    // call scene

    // ok
    // else if (count >= 16 && count <= 34) Application.LoadLevel("Ending3");

    // call scene

    // good
    //else if (count >= 35 && count <= 43) Application.LoadLevel("Ending4");

    // call scene

    // very good
    // else if (count >= 44 && count <= 59) Application.LoadLevel("Ending5");

    // call scene

    // amazing
    //  else if (count >= 60 && count <= 1000000000) Application.LoadLevel("Ending6");

    // call scene


    // }
    // }
}