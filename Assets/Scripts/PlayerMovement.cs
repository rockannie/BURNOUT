using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Slider lifeline;
    
    public Animator Player;
    public static float life = 10;
    public ParticleSystem fire;
    private float bound = 4f;
    // public float speed;
    public AudioSource attackmode;

    public AudioSource noattackmode;
    public float count;
    public CharacterController2D controller;

    public float runSpeed = 40f;

    private float horizontalMove = 0f;

    private bool jump = false;
    private bool fireonoff;
    private bool crouch = false;

    public static PlayerMovement instance;
    // Start is called before the first frame update
    void Start()
    {
        life = 10;
        lifeline.value = life / 10;
        fireonoff = true;
        fire.Play();
        noattackmode.Play();
    }

    private void Awake()
    {
        instance = this;
    }
    //put shift for on and off the particle system
//left and right to walk
// up and left and up and right to run
//if the fire is off for 1 min player should die
//crouch and jump


    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 500)
        {
            //winner
            Debug.Log("winner");
            
        }
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        Player.SetFloat("speed",Mathf.Abs(horizontalMove));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
          Player.SetBool("jump",true);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            
            crouch = true;
           
        }
        else if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            crouch = false;
        }
        // if (Input.GetKeyDown(KeyCode.RightArrow))
        // {
        //     transform.position+=Vector3.right*Time.deltaTime*2;
        // }
        // if (Input.GetKeyDown(KeyCode.LeftArrow))
        // {
        //     transform.position+=Vector3.left*Time.deltaTime*2;
        // }
        // if (Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     transform.position+=Vector3.right*Time.deltaTime*10;
        // }
        // if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     transform.position+=Vector3.right*Time.deltaTime*10;
        // }
        //
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CharacterController2D.instance.speed = 20;
        }
        else if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            CharacterController2D.instance.speed = 10;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            if (fireonoff==true)
            {
                fire.Stop();
                Player.SetBool("fire",false);
                count = 1;
                fireonoff = false;
            }
            else
            {
                fire.Play();
                Player.SetBool("fire",true);
                count = 0;
                fireonoff = true;
            }

        }
    
        if (count <= 10 && count >= 1){
            count += Time.deltaTime;
        }
        else if (count > 10)
        {
            Debug.Log("gameover");
           // SceneManager.LoadScene("gameover");
        }
        
        //
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     
        // }
        
        Vector2 f1 = Camera.main.WorldToScreenPoint(transform.position);
        if (f1.x >= Screen.width-bound || f1.x <= bound)
        { 
            //Debug.Log("f"+f); 
            Camera.main.transform.position = new Vector3(transform.position.x+10f,Camera.main.transform.position.y,Camera.main.transform.position.z);
        }
    }
    
    
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
       
             
        // if (jump){
        //     Player.SetBool("jump", true);
        // }
        // else
        // {
        //     Player.SetBool("jump", false);
        //    
        // }
        //Player.SetBool("jump",false);
    }
    
    public void Onland()
    {
        Player.SetBool("jump",false);
    }
    public void OnCrouching (bool isCrouching)
    {
        Debug.Log("isCrouchin"+isCrouching);
        Player.SetBool("crouch", isCrouching);
        transform.localScale = new Vector3(transform.localScale.x, 3, transform.localScale.z);
        transform.position = new Vector3(transform.position.x, transform.position.y-0.5f, transform.position.z);
    }

}
