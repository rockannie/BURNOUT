using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using UnityEngine.UIElements;


public class componentManager : MonoBehaviour
{
    [SerializeField] healthBar energy;
    [SerializeField] private GameObject player;
    public int Currentenergy;
    [SerializeField] private PlayerMover manageSpeed;
    [SerializeField] private int heal = 10;
    [SerializeField] private Camera playerCam;
    
    // Start is called before the first frame update
    void Start()
    {
        energy.MaxHealth(100);
        StartCoroutine(runEnergy());
        playerCam.orthographicSize = 3;


    }

    private void Update()
    {
        if (energy.energy.value <= 0)
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene().name);
        }

        playerCam.orthographicSize = 3 + (manageSpeed.runSpeed/2);

    }

    IEnumerator runEnergy()
    {
        while (energy.energy.value != 0 && manageSpeed.runSpeed > 0)
        {

            if (manageSpeed.amSlowing || manageSpeed.crouch)
            {
                energy.SetEnergy(heal);
            }

            else
            {
                energy.SetEnergy((manageSpeed.runSpeed)*-0.3f);
            }
            yield return new WaitForSeconds(1);
        }
        
        
    }
    

 
}




