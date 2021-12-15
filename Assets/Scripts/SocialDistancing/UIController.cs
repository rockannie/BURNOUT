using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{

    [SerializeField] private Text instructionTitle;

    [SerializeField] private Text instructionText;

    [SerializeField] private Image instructions;
    
    [SerializeField] private Image scorebkground;

    [SerializeField] private Button startButton;

    [SerializeField] private Text scoreTitle;

    [SerializeField] private Image strike1;

    [SerializeField] private Image strike2;

    [SerializeField] private Image strike3;

    private bool youLost = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        turnOffScoreboard();
        turnOffStrikes();
    }

    // Update is called once per frame
    void Update()
    {
        if (youLost)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene(2);
            //turnOnScoreboard();
        }
    }
    
    public void OnButtonPress()
    {
        instructionTitle.gameObject.SetActive(false);
        instructionText.gameObject.SetActive(false);
        scorebkground.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void turnOffStrikes()
    {
        strike1.gameObject.SetActive(false);
        strike2.gameObject.SetActive(false);
        strike3.gameObject.SetActive(false);
    }

    public void playerStrikes()
    {
        if (strike1.gameObject.activeSelf)
        {
            if (strike2.gameObject.activeSelf)
            {
                if (strike3.gameObject.activeSelf)
                {
                    youLost = true;
                }
                strike3.gameObject.SetActive(true);
            }
            strike2.gameObject.SetActive(true);
        }
        else
        {
            strike1.gameObject.SetActive(true);
        }
    }
    public void turnOffScoreboard()
    {
        instructions.gameObject.SetActive(false);
        scoreTitle.gameObject.SetActive(false);
    }
    public void turnOnScoreboard()
    {
        instructions.gameObject.SetActive(true);
        scoreTitle.gameObject.SetActive(true);
        
    }
}
