using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostmanager : MonoBehaviour
{
    public delegate void movetowardstarget();

    public movetowardstarget movetoplayer;
    public static ghostmanager instance;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        movetoplayer();
    }
}
