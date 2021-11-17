using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class AISDController : MonoBehaviour
{
    
    public Tilemap walkableTilemap;
    
    private Coroutine coroutinevar;

    //Julien code
    private bool hasMoved = true;
    
    private Coroutine MovementCoroutine
    {
        get { return coroutinevar; }
        set
        {
            if (coroutinevar != null)
            {
                StopCoroutine(coroutinevar);
            }

            coroutinevar = value;
        }
    }
    
    //setting up astar objects
    private Vector3Int[,] walkableArea;
    private Astar astar;
    private BoundsInt bounds;
    private Vector3Int direction;
    private List<Spot> roadPath = new List<Spot>();
    
    private Vector2Int GridPositionOfMatchAI
    {
        get
        {
            return (Vector2Int) walkableTilemap.WorldToCell(transform.position);
        }
    }
    
    private Vector2Int GridPositionOfRandom
    {
        get
        {
            var gridSize = walkableTilemap.size;
            var randomPos = new Vector3Int(Random.Range(-gridSize.x, gridSize.x), Random.Range(-gridSize.y, gridSize.y),
                Random.Range(gridSize.z, gridSize.z));
            return (Vector2Int) walkableTilemap.WorldToCell(randomPos);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //tilemap a* setup
        walkableTilemap.CompressBounds();
        bounds = walkableTilemap.cellBounds;

        CreateGrid();
        astar = new Astar(walkableArea, bounds.size.x, bounds.size.y);
    }
    
    private void CreateGrid()
    {
        walkableArea = new Vector3Int[bounds.size.x, bounds.size.y];
        for (int x = bounds.xMin, i = 0; i < (bounds.size.x); x++, i++)
        {
            for (int y = bounds.yMin, j = 0; j < (bounds.size.y); y++, j++)
            {
                if (walkableTilemap.HasTile(new Vector3Int(x, y, 0)))
                {
                    walkableArea[i, j] = new Vector3Int(x, y, 0);
                }
                else
                {
                    walkableArea[i, j] = new Vector3Int(x, y, 1);
                }
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!hasMoved)
            return;
        hasMoved = false;
        roadPath = astar.CreatePath(walkableArea, GridPositionOfMatchAI, GridPositionOfRandom);
        if (roadPath == null)
        {
            return;
        }

        MovementCoroutine = StartCoroutine(keepMoving(roadPath));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    IEnumerator keepMoving(List<Spot> my_path)
    {
        for (int i = 0; i < my_path.Count; i++)
        {
            direction = new Vector3Int(my_path[i].X, my_path[i].Y, 0);
            Vector3 temp = walkableTilemap.GetCellCenterWorld(direction);
            transform.position = temp;
            yield return new WaitForSeconds(.3f);
            //hasMoved = true;
        }
        hasMoved = true;
    }
}
