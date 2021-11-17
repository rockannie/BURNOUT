using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class componentManager : MonoBehaviour
{
    [SerializeField] healthBar energy;
    [SerializeField] private GameObject player;
    public int Currentenergy;
    [SerializeField] private PlayerMover manageSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        energy.MaxHealth(100);
        StartCoroutine(runEnergy());
       
        
    }

    private void Update()
    {
        if (energy.energy.value <= 0)
        {
            saver();
            SceneManager.LoadScene( SceneManager.GetActiveScene().name);
            
        }
        
    }

    IEnumerator runEnergy()
    {
        while (energy.energy.value != 0 && manageSpeed.runSpeed > 0)
        {

            if (manageSpeed.amSlowing)
            {
                energy.SetEnergy(5); 
                Debug.Log("chill bro");
            }

            else
            {
                energy.SetEnergy(-manageSpeed.runSpeed);
            }
            yield return new WaitForSeconds(1);
        }
        
        
    }

    public void saver()
    {
        //First build the player
        var p = new saveFile()
        {
            Energy = energy.energy.value,
            Position = player.transform,
            
        };

        //Then serialize it
        var serializedObject = JsonConvert.SerializeObject(p);
    }

 
}

public class saveFile
{

    public int Points { get; set; }
    public float Energy { get; set; }
    public Transform Position { get; set; }

}


