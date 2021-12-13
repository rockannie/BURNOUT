using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class ProceduralTiles : MonoBehaviour
{
    public TileBase tile1;
    public TileBase tile2;
    public TileBase tile3;
    public TileBase tile4;
    public Tilemap basetile;
    public Tilemap obstacletile;
    public ParticleSystem fire1;
    public ParticleSystem fire2;
    private int width=260;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x<= width;x++)
        {
            basetile.SetTile(new Vector3Int(x, 0, 0), tile1);

        }
        //obstacle tiles 
        for (int y = 0; y < 2; y++)
        {
            for (int x = 6; x < width; x = x + 40)
            {
                if (y == 0)
                    obstacletile.SetTile(new Vector3Int(x, y, 0), tile2);
                else if (y==1)
                {
                    obstacletile.SetTile(new Vector3Int(x, y, 0), tile3);
                }
                
            }
        }

        for (float x = 2; x < 500; x += 80)
        {
            ParticleSystem pos = Instantiate(fire1, new Vector3(x, -1.5f, 0), quaternion.identity);
            pos.transform.localScale = new Vector3(1, 1, 0); 
            pos.Play();  
        }
        //obstacle air tiles
        for (int x = 100; x <160; x = x + 10)
        {
            obstacletile.SetTile(new Vector3Int(x,3,0),tile4);
            obstacletile.SetTile(new Vector3Int(x+1,3,0),tile4);
            obstacletile.SetTile(new Vector3Int(x+2,3,0),tile4);
        } 
        //fire particle system
        for (float x = 200f; x <= 280; x=x+1)
        {
            ParticleSystem pos = Instantiate(fire2, new Vector3(x, -4.5f, 0), quaternion.identity);
            pos.transform.localScale = new Vector3(1, 1, 0);
            pos.Play();
        }
        
       
    }

 

    // Update is called once per frame
    void Update()
    {
        int layermaskno2 = LayerMask.GetMask("danger");
        //ground tile
        Collider2D col = Physics2D.OverlapCircle(new Vector2(transform.position.x,transform.position.y-1f), 1f, layermaskno2);
        if ( col != null && col.tag == "danger")
        {
            Debug.Log("dead");
            PlayerMovement.life--;
            print(PlayerMovement.life);
            PlayerMovement.instance.lifeline.value = PlayerMovement.life / 10f;
            Debug.Log(PlayerMovement.instance.lifeline.value);
        }
    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.DrawSphere(new Vector3(transform.position.x,transform.position.y-1f,transform.position.z),1f);
    // }
}
