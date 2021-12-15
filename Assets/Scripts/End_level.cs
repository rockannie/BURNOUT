using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_level : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(SceneManager.GetActiveScene().name=="Thyme1")
            {
                SceneManager.LoadScene(2); 
            }
            
            if (SceneManager.GetActiveScene().name == "EndScene")
            {
                SceneManager.LoadScene(0); 
            }
        }
    }
}
