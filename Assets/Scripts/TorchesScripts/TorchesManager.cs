using System;
using System.Collections.Generic;
using UnityEngine;

public class TorchesManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject flame = transform.GetChild(0).gameObject;
            Debug.Log(flame.name);
            if (!flame.activeSelf)
            {
                MiniGameManager.sharedManager.orderLit.Add(gameObject.tag);
                flame.SetActive(true);
            } 
        }
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         GameObject flame = transform.GetChild(0).gameObject;
    //         Debug.Log(flame.name);
    //         if (!flame.activeSelf)
    //         {
    //             orderLit.Add(other.gameObject.tag);
    //             flame.SetActive(true);
    //         } 
    //     }
    // }

    
}
