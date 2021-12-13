using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowPlayer : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] private int enemySpeed;

    void Update()
    {
       transform.position = Vector2.Lerp(transform.position, player.position, Time.deltaTime * enemySpeed);
    }
}
