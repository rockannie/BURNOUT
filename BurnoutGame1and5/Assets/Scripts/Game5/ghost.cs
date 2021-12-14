using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
    private bool m_FacingRight = false;

    public Animator Ghost;
    // Start is called before the first frame update
    void Start()
    {
        ghostmanager.instance.movetoplayer += movetowardsplayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void movetowardsplayer()
    {
        Ghost.SetBool("walk",true);
        Ghost.SetBool("sawplayer",false);
        if(transform.position.x - PlayerMovement.instance.transform.position.x > 0 && transform.localScale.x>0)
        {
            Flip();
        }
        if(transform.position.x - PlayerMovement.instance.transform.position.x <= 0 && transform.localScale.x<0)
        {
            Flip();
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(PlayerMovement.instance.transform.position.x, transform.position.y, transform.position.z),
            Time.deltaTime*6);
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

}
