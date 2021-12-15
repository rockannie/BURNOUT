using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopDownCharacterController : MonoBehaviour
{
    public float speed;
    private Animator anim;
    private bool movingLeft;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Torches")
        {
            Time.timeScale = 1;
        }
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
            anim.SetBool("isGoingDown", false);
            anim.SetBool("isGoingUp", false);
            dir = Vector3.left;
            //movingLeft = true;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("isRunningSide", false);
            anim.SetBool("isGoingDown", false);
            anim.SetBool("isGoingUp", true);
            dir = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isRunningSide", true);
            anim.SetBool("isGoingDown", false);
            anim.SetBool("isGoingUp", false);
            dir = Vector3.right;
            //movingLeft = false;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("isRunningSide", false);
            anim.SetBool("isGoingDown", true);
            anim.SetBool("isGoingUp", false);
            dir = Vector3.down;
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