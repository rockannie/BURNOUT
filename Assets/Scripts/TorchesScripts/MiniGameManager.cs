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
}
