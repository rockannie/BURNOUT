using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lifeline : MonoBehaviour
{
    

    public static Lifeline instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerMovement.life <= 0)
        {
            if(SceneManager.GetActiveScene().name=="MiniGame1")
                SceneManager.LoadScene(0);
            if(SceneManager.GetActiveScene().name=="MiniGame5")
                SceneManager.LoadScene(4);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMovement.life--;
            print(PlayerMovement.life);
            PlayerMovement.instance.lifeline.value = PlayerMovement.life / 10f;
            Debug.Log(PlayerMovement.instance.lifeline.value);
        }

        if (gameObject.tag == "bullet")
        {
            Destroy(gameObject);
        }
   
    }

    // private void OnCollisionStay2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "Player")
    //     {
    //         PlayerMovement.life--;
    //         print(PlayerMovement.life);
    //         lifeline.value = PlayerMovement.life / 10;
    //     }
    // }
}
