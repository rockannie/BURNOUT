using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletmoveright : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        if (-transform.position.x + PlayerMovement.instance.transform.position.x+15 < 0)
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        StartCoroutine(movement());
    }

    // Update is called once per frame

    IEnumerator movement()
    {
        
        transform.position += Vector3.right * Time.deltaTime * 3;
        yield return new WaitForSeconds(0f);
        StartCoroutine(movement());
    }

}
