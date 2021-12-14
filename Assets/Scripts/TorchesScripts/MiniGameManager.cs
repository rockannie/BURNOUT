using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public List<string> orderLit = new List<string>();
    public static string[] neededOrder = {"SpringTorch", "SummerTorch", "FallTorch", "WinterTorch"};

    public static MiniGameManager sharedManager;

    private void Awake()
    {
        sharedManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (var VARIABLE in sharedManager.orderLit)
            {
                Debug.Log(VARIABLE);
            }
            Debug.Log(checkOrder());
        }

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            extinguishTorches();
        }
    }
    
    private bool checkOrder()
    {
        bool returnVal = true;
        if (sharedManager.orderLit.Count == neededOrder.Length)
        {
            for (int i = 0; i < neededOrder.Length; i++)
            {
                if (sharedManager.orderLit[i] != neededOrder[i])
                {
                    returnVal = false;
                }
            }
        }
        else
        {
            returnVal = false;
        }
        return returnVal;
    }

    private void extinguishTorches()
    {
        TorchesManager springTorch = GameObject.FindGameObjectWithTag("SpringTorch").GetComponent<TorchesManager>();
        TorchesManager summerTorch = GameObject.FindGameObjectWithTag("SummerTorch").GetComponent<TorchesManager>();
        TorchesManager fallTorch = GameObject.FindGameObjectWithTag("FallTorch").GetComponent<TorchesManager>();
        TorchesManager winterTorch = GameObject.FindGameObjectWithTag("WinterTorch").GetComponent<TorchesManager>();
        
        springTorch.extinguish();
        summerTorch.extinguish();
        fallTorch.extinguish();
        winterTorch.extinguish();
    }
}
