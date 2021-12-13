using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletmove : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
//after sometime destroy the object 
        if (transform.position.x - PlayerMovement.instance.transform.position.x+15 < 0)
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
    private void Awake()
    {
        StartCoroutine("movement");
   
    }

    // Update is called once per frame
 
    IEnumerator movement()
    { 
       
            transform.position += Vector3.left * Time.deltaTime*3;
            yield return new WaitForSeconds(0f);
        StartCoroutine(movement());
    }

    
}
