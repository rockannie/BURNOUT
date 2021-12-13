using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timer = 2*60f;

    public Text timertext;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timerGame());
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    IEnumerator timerGame()
    {
        for (float i = timer; i >= 0f; i -= 1)
        {
            string k = i.ToString();
            timertext.text = "Timer: "+k;
            if (i < 30)
            {
                timertext.color=Color.red;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
