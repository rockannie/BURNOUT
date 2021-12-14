using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public Animator Animator;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Animator.SetBool("Fall", true);
    }
}
