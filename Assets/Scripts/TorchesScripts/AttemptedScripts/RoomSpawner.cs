using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] int openingDir;

    private RoomTemplates templates;
    private bool roomSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn()
    {
        if(roomSpawned == false){
            if (openingDir == 1)
            {
                Instantiate(templates.bRooms[Random.Range(0, templates.bRooms.Length)],transform.position, Quaternion.identity);
            }else if (openingDir == 2)
            {
                Instantiate(templates.tRooms[Random.Range(0, templates.tRooms.Length)],transform.position, Quaternion.identity);
            }else if (openingDir == 3)
            {
                Instantiate(templates.lRooms[Random.Range(0, templates.lRooms.Length)],transform.position, Quaternion.identity);
            }else if (openingDir == 3)
            {
                Instantiate(templates.rRooms[Random.Range(0, templates.rRooms.Length)],transform.position, Quaternion.identity);
            }
            roomSpawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint") && other.gameObject.GetComponent<RoomSpawner>().roomSpawned == true)
        {
            Destroy(gameObject);
        }
    }
}
