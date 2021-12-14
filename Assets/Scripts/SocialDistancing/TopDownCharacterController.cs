using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public float speed;
    private Animator anim;
    private bool movingLeft;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveMatchperson();
    }

    private void MoveMatchperson()
    {

        Vector3 dir = Vector3.zero;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("isRunningSide", true);
            dir = Vector3.left;
            anim.SetBool("isGoingDown", false);
            anim.SetBool("isGoingUp", false);
            //movingLeft = true;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("isRunningSide", false);
            dir = Vector3.up;
            anim.SetBool("isGoingDown", false);
            anim.SetBool("isGoingUp", true);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isRunningSide", true);
            dir = Vector3.right;
            anim.SetBool("isGoingDown", false);
            anim.SetBool("isGoingUp", false);
            //movingLeft = false;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("isRunningSide", false);
            dir = Vector3.down;
            anim.SetBool("isGoingDown", true);
            anim.SetBool("isGoingUp", false);
        }

        dir.Normalize();

        if (dir.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (dir.x < 0 && facingRight)
        {
            Flip();
        }
        
        if (dir.magnitude == 0)
        {
            anim.SetBool("isGoingDown", false);
            anim.SetBool("isGoingUp", false);
            anim.SetBool("isRunningSide", false);
        }

        transform.position += dir * Time.deltaTime * speed;
    }
    
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 objScale = transform.localScale;
        objScale.x *= -1;
        transform.localScale = objScale;
    }
}