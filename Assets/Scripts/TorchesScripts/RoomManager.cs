using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    Dictionary<int, Vector2Int> directions = new Dictionary<int, Vector2Int>()
    {
        {
            1, Vector2Int.up * 16
        },
        {
            2, Vector2Int.down * 16
        },
        {
            3, Vector2Int.right * 16
        },
        {
            4, Vector2Int.left * 16
        }
    };

    [SerializeField] private GameObject startingRoomObj;
    [SerializeField] private List<GameObject> topRooms;
    [SerializeField] private List<GameObject> bottomRooms;
    [SerializeField] private List<GameObject> rightRooms;
    [SerializeField] private List<GameObject> leftRooms;
    [SerializeField] private int maxRooms;
    
    private Vector2Int startingRoom = new Vector2Int(0, 0);
    private Vector2Int currPos;
    private List<Vector2Int> rooms = new List<Vector2Int>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        currPos = startingRoom;
        // call drunkenWalk1, drunkenWalk2, then capRooms
        drunkenWalk1();
    }

    // create half the rooms
    /*
     * Questions: how to detect if room is open in that random direction?
     * Are different templates even needed?
     * Do I only need the one 4 way room and then cap its holes?
     */
    void drunkenWalk1()
    {
        Instantiate(startingRoomObj, new Vector3(startingRoom.x,startingRoom.y,0), startingRoomObj.transform.rotation);
        for (int i = 0; i < maxRooms/2; i++)
        {
            int dir = Random.Range(1, 5);
            
        }
    }

    // create the rest from the first half of rooms
    void drunkenWalk2()
    {
        
    }

    // Cap any holes left from openings in rooms after creation
    void capRooms()
    {
        
    }
    
    // checking if there's an already existing room at that position
    bool hasRoom(Vector2Int pos)
    {
        foreach (var room in rooms)
        {
            if (room == pos)
            {
                return false;
            }
        }
        return true;
    }
}
