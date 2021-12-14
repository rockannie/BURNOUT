using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class Ghostwalk : MonoBehaviour
{
    private bool m_FacingRight = false;
    public GameObject leftbulletfire;
    public GameObject rightbulletfire;
    public Animator Player;
    public Animator Ghost;
    public static Ghostwalk ghostinstance;
    private int play;
    public AudioSource attackmode;

    public AudioSource noattackmode;
    // Start is called before the first frame update
    void Start()
    {
        ghostinstance = this;
    }

    // Update is called once per frame
    void Update()
    {

//         
        if (Player.GetBool("fire"))
        {
            Ghost.SetBool("sawplayer",true);
            Ghost.SetBool("walk",false);
            if (play == 0)
            {
                //noattackmode.Stop();
                attackmode.Play();
                play = 1;
            }
            //if (transform.position.x - PlayerMovement.instance.transform.position.x > 0 && transform.localScale.x<0)
            //{
                //Debug.Log("player is front and ghost facing the player");
            //}
            if(transform.position.x - PlayerMovement.instance.transform.position.x > 0 && transform.localScale.x>0)
            {
                //Debug.Log("player is front and ghost not facing the player");
                Flip();
                
            }
            //if (transform.position.x - PlayerMovement.instance.transform.position.x <= 0 && transform.localScale.x>0)
            //{
               // Debug.Log("player is ahead and ghost facing the player");
            //}
            if(transform.position.x - PlayerMovement.instance.transform.position.x <= 0 && transform.localScale.x<0)
            {
                //Debug.Log("player is ahead and ghost not facing the player");
                Flip();
            }
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(PlayerMovement.instance.transform.position.x, transform.position.y, transform.position.z),
               Time.deltaTime*2);
            //transform.LookAt(new Vector3(-(PlayerMovement.instance.transform.position.x),PlayerMovement.instance.transform.position.y,PlayerMovement.instance.transform.position.z));
            // Debug.Log("attack player");
        }
        else {
        
//Debug.Log("move");
Ghost.SetBool("walk",true);
Ghost.SetBool("sawplayer",false);
if (play == 1)
{
    attackmode.Stop();
    //noattackmode.Play();
    play = 0;
}
int layermaskno2 = LayerMask.GetMask("obstacle");
            if (m_FacingRight)
            {
                transform.position += Vector3.right * Time.deltaTime * 2;
            }
            else
            {
                transform.position += Vector3.left * Time.deltaTime * 2;
            }

            Collider2D col = Physics2D.OverlapCircle(transform.position, 1f, layermaskno2);
            if (col != null)
            {
                Debug.Log("obstacle");
                Flip();
            }
        }

        if (PlayerMovement.instance.transform.position.x - transform.position.x > 20)
        {
           
                transform.position += new Vector3(80, 0, 0);
              
        }
        if (transform.position.x >= 200 && transform.position.x <= 280)
        {
            transform.position += new Vector3(100, 0, 0);
        }

        if (transform.position.x > 450)
        {
           // noattackmode.Play();
            attackmode.Stop();
            gameObject.SetActive(false);
         
        }
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position,Vector2.left*3);
        Gizmos.DrawRay(transform.position,Vector2.right*3); 
    }
    

   
       
    }
 