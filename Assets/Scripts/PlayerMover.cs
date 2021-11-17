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
    public int runSpeed = 10;
    [SerializeField] int runSpeedMax = 10;
    private Rigidbody2D body;



    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update () {

        //transform.position += Vector3.right * Time.deltaTime * runSpeed;
        if (run)
        {
            body.AddForce(transform.right * runSpeed);
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
        
        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            StartCoroutine(slowBurn());
        }

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
        
        if (runSpeed < runSpeedMax)
        {
            runSpeed++;

        }
       
    }


    IEnumerator slowBurn()
    {
        if (runSpeed > 0)
            {
                runSpeed--;
                //yield return new WaitForSeconds(2);
                Debug.Log("Slow");
            }

        yield return new WaitForSeconds(2);
    }

    IEnumerator speedUp()
    {
        if (runSpeed < runSpeedMax)
        {
            runSpeed++;
            Debug.Log("Speed");
            yield return new WaitForSeconds(2);
            
        }

        yield return null;
    }







}
