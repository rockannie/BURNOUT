using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{

    [SerializeField] private Text instructionTitle;

    [SerializeField] private Text instructionText;

    [SerializeField] private Image instructions;
    
    [SerializeField] private Image scorebkground;

    [SerializeField] private Button startButton;

    [SerializeField] private Text scoreTitle;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        turnOffScoreboard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPress()
    {
        instructionTitle.gameObject.SetActive(false);
        instructionText.gameObject.SetActive(false);
        scorebkground.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        Time.timeScale = 1;
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
