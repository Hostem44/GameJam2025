using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonController : MonoBehaviour
{
    public int LoopLength = 5;
    public int maxRooms = 10;
    public Transform Player;
    public List<GameObject> mains;
    public List<GameObject> rooms;
    public GameObject[] dungeon;
    public GameObject[] other_rooms;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        dungeon = new GameObject[LoopLength];
        other_rooms = new GameObject[LoopLength * maxRooms];


        // Generating main rooms
        float y_offset = 0.0f;
        for (int i = 0; i < LoopLength; i++)
        {
            int roomNum = Random.Range(0, mains.Count);
            GameObject room = Instantiate(mains[roomNum]);
            room.transform.position = new Vector3(0, y_offset, 0);
            room.transform.parent = transform;
            room.GetComponent<MainRoom>().dungeon_index = i;
            room.GetComponent<MainRoom>().dungeon = gameObject;

            dungeon[i] = room;
            // Offset new rooms
            y_offset += 200.0f;
        }

        List<int> up_index = new List<int>();
        List<int> down_index = new List<int>();
        List<int> left_index = new List<int>();
        List<int> right_index = new List<int>();

        for (int r = 0; r < rooms.Count; r++)
        {
            Room test_room = rooms[r].gameObject.GetComponent<Room>();
            if (test_room.HasUp() == true)
            {
                up_index.Add(r);
            }
            if (test_room.HasDown() == true)
            {
                down_index.Add(r);
            }
            if (test_room.HasLeft() == true)
            {
                left_index.Add(r);
            }
            if (test_room.HasRight() == true)
            {
                right_index.Add(r);
            }
        }


        int room_index = 0;
        for (int main = 0; main < LoopLength; main++)
        {
            GameObject room = dungeon[main];
            MainRoom mainRoom = room.gameObject.GetComponent<MainRoom>();
            if (mainRoom.HasUp() == true && down_index.Count != 0)
            {
                int room_to_use = down_index[Random.Range(0, down_index.Count)];

                GameObject new_room = Instantiate(rooms[room_to_use]);
                other_rooms[room_index] = new_room;
                Room new_room_script = new_room.GetComponent<Room>();
                Vector3 up = mainRoom.GetUp().position;

                new_room.transform.position += up - new_room_script.GetDown().position;
                new_room.transform.parent = transform;
                new_room_script.dungeon = gameObject;
                room_index += 1;
            }
            if (mainRoom.HasDown() == true && up_index.Count != 0)
            {
                int room_to_use = up_index[Random.Range(0, up_index.Count)];

                GameObject new_room = Instantiate(rooms[room_to_use]);
                other_rooms[room_index] = new_room;
                Room new_room_script = new_room.GetComponent<Room>();
                Vector3 down = mainRoom.GetDown().position;

                new_room.transform.position += down - new_room_script.GetUp().position;
                new_room.transform.parent = transform;
                new_room_script.dungeon = gameObject;
                room_index += 1;
            }
            if (mainRoom.HasLeft() == true && right_index.Count != 0)
            {
                int room_to_use = right_index[Random.Range(0, right_index.Count)];

                GameObject new_room = Instantiate(rooms[room_to_use]);
                other_rooms[room_index] = new_room;
                Room new_room_script = new_room.GetComponent<Room>();
                Vector3 left = mainRoom.GetLeft().position;

                new_room.transform.position += left - new_room_script.GetRight().position;
                new_room.transform.parent = transform;
                new_room_script.dungeon = gameObject;
                room_index += 1;
            }
            if (mainRoom.HasRight() == true && left_index.Count != 0)
            {
                int room_to_use = left_index[Random.Range(0, left_index.Count)];

                GameObject new_room = Instantiate(rooms[room_to_use]);
                other_rooms[room_index] = new_room;
                Room new_room_script = new_room.GetComponent<Room>();
                Vector3 right = mainRoom.GetRight().position;

                new_room.transform.position += right - new_room_script.GetLeft().position;
                new_room.transform.parent = transform;
                new_room_script.dungeon = gameObject;
                room_index += 1;
            }

        }        


    }
}
