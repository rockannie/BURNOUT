using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerSD : MonoBehaviour
{
    public float timer = 90f;
    public Text timertext;

    //[SerializeField] private Image background;
    [SerializeField] private Canvas popupController;

    private UIController controllerUI;

    void Start()
    {
        controllerUI = popupController.GetComponent<UIController>();
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
                //show how many match-people they lit
                Time.timeScale = 0;
                SceneManager.LoadScene(3);
                //controllerUI.turnOnScoreboard();
                //background.gameObject.SetActive(true);
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
