using System;
using System.Collections.Generic;
using UnityEngine;

public class TorchesManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject flame = transform.GetChild(0).gameObject;
            if (!flame.activeSelf)
            {
                MiniGameManager.sharedManager.orderLit.Add(gameObject.tag);
                flame.SetActive(true);
            } 
        }
    }

    public void extinguish()
    {
        GameObject flame = transform.GetChild(0).gameObject;
        if (flame.activeSelf)
        {
            MiniGameManager.sharedManager.orderLit.Remove(gameObject.tag);
            flame.SetActive(false);
        } 
    }
}
