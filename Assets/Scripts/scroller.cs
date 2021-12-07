using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class scroller : MonoBehaviour
{
    [SerializeField] int platformSpeed = 1;
 
    
    // Update is called once per frame
    void FixedUpdate()
    {
        
        transform.position += Vector3.left * Time.deltaTime * platformSpeed;
    }
}
