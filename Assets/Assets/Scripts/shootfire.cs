using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Mathematics;
using UnityEngine;

public class shootfire : StateMachineBehaviour
{
    

    private GameObject pos;
    private float bulletpersec = 1f;
    private float lastbulletfired = 0f;

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // Debug.Log(Ghostwalk.ghostinstance.name);
        if (Time.time - lastbulletfired > 2f / bulletpersec)
        {
            if (Ghostwalk.ghostinstance.transform.localScale.x < 0)
            {
                pos = Instantiate(Ghostwalk.ghostinstance.leftbulletfire, Ghostwalk.ghostinstance.transform.position - new Vector3(3f, 0, 0)+new Vector3(0,1.3f,0),
                    quaternion.identity);
                pos.transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
                pos.transform.localScale = new Vector3(pos.transform.localScale.x,-1f,pos.transform.localScale.z);
            }
            else
            {
                pos = Instantiate(Ghostwalk.ghostinstance.rightbulletfire, Ghostwalk.ghostinstance.transform.position + new Vector3(3f, 0, 0)+new Vector3(0,1.3f,0),
                    quaternion.identity);
                pos.transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
                pos.transform.localScale = new Vector3(pos.transform.localScale.x,1f,pos.transform.localScale.z);
            }
            pos.SetActive(true);
            
            lastbulletfired = Time.time;
        }
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        // pos = Instantiate(Ghostwalk.ghostinstance.bulletfire, Ghostwalk.ghostinstance.transform.position - new Vector3(3f, 0, 0),
        //     quaternion.identity);
        // pos.SetActive(true);
    }
}
