using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSD : MonoBehaviour
{
    public float timer = 90f;
    public Text timertext;

    void Start()
    {
        StartCoroutine(timerGame()); 
    }
    /*void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            
        }
    }*/

    IEnumerator timerGame()
    {
        for (float i = timer; i >= 0f; i -= 1)
        {
            string k = i.ToString();
            timertext.text = "Timer:" + k;
            if (i < 30)
            {
                timertext.color = Color.red;
            }

            if (i == 0)
            {
                //end game
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
