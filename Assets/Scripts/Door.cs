using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject room;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && Input.GetKey(KeyCode.E))
        {
            // Locate the next room
            MainRoom room_script = room.GetComponent<MainRoom>();
            DungeonController dungeon_script = room_script.dungeon.GetComponent<DungeonController>();
            int next_index = (room_script.dungeon_index + 1) % dungeon_script.LoopLength;
            GameObject next_room = dungeon_script.dungeon[next_index];

            // Teleport the player to next room
            Vector3 next_position = next_room.GetComponent<MainRoom>().entry_point.position;
            collision.gameObject.transform.position = next_position;
        }
    }
    
}
