using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBONK : MonoBehaviour
{

    public healthBar HealthBar;
    [SerializeField] int damage = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Ghost")
        {
            HealthBar.SetEnergy(-damage);
        }
    }
}
