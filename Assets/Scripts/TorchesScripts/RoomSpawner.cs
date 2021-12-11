using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] int openingDir;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (openingDir == 1)
        {
            //needs bottom door
        }else if (openingDir == 2)
        {
            // needs top door
        }else if (openingDir == 3)
        {
            // needs left door
        }else if (openingDir == 3)
        {
            // needs right door
        }
    }
    

}
