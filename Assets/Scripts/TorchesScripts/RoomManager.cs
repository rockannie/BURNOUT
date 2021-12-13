using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

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

    [SerializeField] private GameObject roomTemplate;
    [SerializeField] private GameObject[] torches;
    [SerializeField] private int maxRooms;
    
    private Vector2Int startingRoom = new Vector2Int(0, 0);
    private Vector2Int currPos;
    private List<Room> rooms = new List<Room>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        // call drunkenWalk1, drunkenWalk2, then instantiate, then place torches
        drunkenWalk1();
        drunkenWalk2();
        foreach (Room room in rooms)
        {
            InstantiateRoomWithDoors(room);
        }
        placeTorches();
    }

    // create half the rooms
    void drunkenWalk1()
    {
        Room currentRoom = new Room(startingRoom);
        rooms.Add(currentRoom);
        while(rooms.Count < maxRooms/2)
        {
            int dir = Random.Range(1, 5);
            Vector2Int newPos = currentRoom.Pos + directions[dir];
            if (!hasRoom(newPos))
            {
                currentRoom = CreateNewRoomWithDoors(dir, currentRoom);
            }
        }
    }

    // create the rest from the first half of rooms
    void drunkenWalk2()
    {
        while (rooms.Count < maxRooms)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                Room currentRoom = rooms[i];
                int dir = Random.Range(1, 5);
                Vector2Int newPos = currentRoom.Pos + directions[dir];
                if (!hasRoom(newPos))
                {
                    CreateNewRoomWithDoors(dir, currentRoom);
                    if (rooms.Count == maxRooms)
                    {
                        break;
                    }
                }
            }
        }
    }

    // checking if there's an already existing room at that position
    bool hasRoom(Vector2Int pos)
    {
        foreach (var room in rooms)
        {
            if (room.Pos == pos)
            {
                return true;
            }
        }
        return false;
    }

    Room CreateNewRoomWithDoors(int dir, Room fromRoom)
    {
        Room room = new Room(fromRoom.Pos + directions[dir]);
        if (dir == 1)
        {
            fromRoom.hasUpDoor = true;
            room.hasDownDoor = true;
        }
        else if (dir == 2)
        {
            fromRoom.hasDownDoor = true;
            room.hasUpDoor = true;
        }
        else if (dir == 3)
        {
            fromRoom.hasRightDoor = true;
            room.hasLeftDoor = true;
        }
        else if (dir == 4)
        {
            fromRoom.hasLeftDoor = true;
            room.hasRightDoor = true;
        }
        rooms.Add(room);
        return room;
    }

    Room updateDoors(Room room)
    {
        Room updatedRoom = room;
        for (int i = 1; i < 5; i++)
        {
            if (i == 1 && hasRoom(room.Pos + directions[i]))
            {
                updatedRoom.hasUpDoor = true;
            }

            if (i == 2 && hasRoom(room.Pos + directions[i]))
            {
                updatedRoom.hasDownDoor = true;
            }

            if (i == 3 && hasRoom(room.Pos + directions[i]))
            {
                updatedRoom.hasRightDoor = true;
            }

            if (i == 4 && hasRoom(room.Pos + directions[i]))
            {
                updatedRoom.hasLeftDoor = true;
            }
        }

        return updatedRoom;
    }
    
    GameObject InstantiateRoomWithDoors(Room room)
    {
        GameObject instantiatedRoom = GameObject.Instantiate(roomTemplate, new Vector3(room.Pos.x, room.Pos.y, 0), quaternion.identity);
        RoomController doors= instantiatedRoom.GetComponent<RoomController>();
        if (room.hasUpDoor)
        {
            doors.UpDoor.SetActive(false);
        }
        if (room.hasDownDoor)
        {
            doors.DownDoor.SetActive(false);
        }
        if (room.hasRightDoor)
        {
            doors.RightDoor.SetActive(false);
        }
        if (room.hasLeftDoor)
        {
            doors.LeftDoor.SetActive(false);
        }
        return instantiatedRoom;
    }

    void placeTorches()
    {
        List<Room> rooms = this.rooms;
        foreach (GameObject torch in torches)
        {
            int indexNum = Random.Range(0, rooms.Count);
            Room torchRoom = rooms[indexNum];
            rooms.Remove(rooms[indexNum]);
            Vector2Int pos = new Vector2Int(torchRoom.Pos.x + Random.Range(-5,6), torchRoom.Pos.y + Random.Range(-5,6));
            Instantiate(torch, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
        }
    }
}

class Room
{
    public Room(Vector2Int pos)
    {
        Pos = pos;
        hasDownDoor = false;
        hasLeftDoor = false;
        hasRightDoor = false;
        hasUpDoor = false;
    }
    
    public Vector2Int Pos { get; set; }
    
    public bool hasRightDoor { get; set; }
    public bool hasLeftDoor { get; set; }
    public bool hasUpDoor { get; set; }
    public bool hasDownDoor { get; set; }
}
