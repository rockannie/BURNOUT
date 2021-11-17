using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findPlayer : MonoBehaviour
{
    
        [SerializeField] public Transform player;
        [SerializeField] public Animator animator;
    
        void Update()
        {
            if (Vector2.Distance(transform.position, player.position) < 3)
            {
                animator.SetBool("isAttack", true);
                
            
            }

            else
            {
                animator.SetBool("isAttack", false);
            }
        }
        
}

