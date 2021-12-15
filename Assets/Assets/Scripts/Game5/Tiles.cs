using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tiles : MonoBehaviour
{
    public TileBase tile1;
    public Tilemap basetile;
    private int width=260;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x<= width;x++)
        {
            basetile.SetTile(new Vector3Int(x, 0, 0), tile1);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
