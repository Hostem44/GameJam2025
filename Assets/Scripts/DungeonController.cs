using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonController : MonoBehaviour
{
    public int LoopLength = 5;
    public Transform Player;
    public List<GameObject> rooms;
    public GameObject[] dungeon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        dungeon = new GameObject[LoopLength];


        float y_offset = 0.0f;
        for (int i = 0; i < LoopLength; i++)
        {
            int roomNum = Random.Range(0, rooms.Count);
            GameObject room = (GameObject)Instantiate(rooms[roomNum]);
            room.transform.position = new Vector3(0, y_offset, 0);
            room.transform.parent = transform;
            room.GetComponent<Room>().dungeon_index = i;
            
            dungeon[i] = room;
            // Offset new rooms
            y_offset += 20.0f;
        } 
    }
}
