using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject room;
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && Input.GetKey(KeyCode.E))
        {
            GameObject player = collision.gameObject;
            DungeonController dungeon_con = room.transform.parent.gameObject.GetComponent<DungeonController>();
            Room room_comp = room.GetComponent<Room>();
            Debug.Log(room_comp);
            int next_index = room_comp.dungeon_index;
            next_index = (next_index + 1) % dungeon_con.LoopLength;

            GameObject next_room = dungeon_con.dungeon[next_index];
            Vector3 next_position = next_room.GetComponent<Room>().entry_point.position;
            player.transform.position = next_position;
        }
    }
    
}
