using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {


    private float timeLimit = 3;
    public bool timerOn;
    public Text text;

    // Update is called once per frame
    private void Start()
    {
        timerOn = false;
        text.enabled = false;
    }
    void Update ()
    {
        if (timerOn)
        {
            if (timeLimit > 1)
            {
                //Display the text
                text.enabled = true;
                // Decrease time Limit.
                timeLimit -= Time.deltaTime;
            }
            else
            {
                timeLimit = 4;
                timerOn = false;
                text.enabled = false;
            }
        }
    }
}
