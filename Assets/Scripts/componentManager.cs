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
        while (energy.energy.value != 0)
        {
            energy.SetEnergy(-2);
            yield return new WaitForSeconds(1);
            Debug.Log("loseEnergy");
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


