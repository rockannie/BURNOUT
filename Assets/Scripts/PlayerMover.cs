using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    //Code adapted from class example
    
    public Movement controller;
    public Animator Animator;
    public bool jump = false;
    bool crouch = false;
    bool run = true;
    public float runSpeed = 10f;
    [SerializeField] int runSpeedMax = 10;
    private Rigidbody2D body;
    Coroutine slowDownCoroutine;
    private bool amSlowing = false;
    [SerializeField] private float speedBy = 2f;
    [SerializeField] private float slowBy = 0.5f;



    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        StartCoroutine(speedUp());
    }


    // Update is called once per frame
    void Update () {

        //transform.position += Vector3.right * Time.deltaTime * runSpeed;
        if (runSpeed > 0 && !amSlowing)
        {
            body.AddForce(transform.right * runSpeed);
            
            if (body.velocity.x > runSpeedMax)
            {
                 Vector3 tempVelocity= body.velocity;
                 tempVelocity.x = runSpeedMax;
                 body.velocity = tempVelocity;
            }
        }
        
        else if (runSpeed > 0 && amSlowing && body.velocity.x > 0)
        {
            body.AddForce(transform.right * -1 * runSpeed);
        }

        else
        {
            body.velocity = new Vector2(0,0);
        }
        
     


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = true;
            Animator.SetBool("Jump", true);

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            crouch = true;
            Animator.SetBool("Crouch", true);
            
            
            
        } else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            crouch = false;
        }
        

            amSlowing = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));

        

    }

   
  

    void FixedUpdate ()
    {
        // Move our character
        controller.Move(crouch, jump);
        
            jump = false;
            
        if (jump){
            Animator.SetBool("Jump", true);
        }
        else
        {
            Animator.SetBool("Jump", false);
           
        }
        
       
    }


    IEnumerator slowBurn()
    {
        while (runSpeed > 0)
            {
                runSpeed--;
                yield return new WaitForSeconds(0.5f);
            }

        slowDownCoroutine = null;


    }

    IEnumerator speedUp()
    {
        while (true)
        {
            if (amSlowing && runSpeed > 0)
            {
                runSpeed -= slowBy * Time.deltaTime;
                
            }
            
            else if (!amSlowing && runSpeed < runSpeedMax)
            {
                runSpeed+= speedBy * Time.deltaTime;
                
            }

            yield return null;

        }
        
    }







}
