using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Addenergy : MonoBehaviour
{
    [SerializeField] healthBar energy;
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            energy.SetEnergy(10);
            Destroy(gameObject);
        }

    }
}
