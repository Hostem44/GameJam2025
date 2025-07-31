using UnityEngine;
using UnityEngine.Tilemaps;

public class Tiles : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile tile;

    public int pass_through_radius = 5;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player Aura"))
        {
            Transform player = collision.gameObject.transform;
            Vector3Int player_pos = tilemap.WorldToCell(player.position);

            for (int x = player_pos.x - pass_through_radius; x <= player_pos.x + pass_through_radius; x++)
            {
                for (int y = player_pos.y - pass_through_radius; y <= player_pos.y + pass_through_radius; y++)
                {

                    Vector2 tile_position = new Vector2(x, y);
                    Vector3Int tile_pos = new Vector3Int(x, y, (int)transform.position.z);
                    Vector2 player_position = new Vector2(player.position.x, player.position.y);
                    if (tile_position.y > player_position.y)
                    {
                        //continue;
                    }
                    Vector2 offset = tile_position - player_position;
                    float alpha = offset.magnitude * offset.magnitude;
                    alpha /= 10;
                    if (alpha > 1.0f)
                    {
                        alpha = 1.0f;
                    }
                    if (alpha < 0.0f)
                    {
                        alpha = 0.0f;
                    }
                    tilemap.SetTileFlags(tile_pos, TileFlags.None);
                    Color alpha_color = new Color(1.0f, 1.0f, 1.0f, alpha);
                    tilemap.SetColor(tile_pos, alpha_color);
                    tilemap.RefreshTile(tile_pos);
                }
            }

            //tilemap.RemoveTileFlags(pos, TileFlags.LockColor);


            //tilemap.SetTile(pos, tile);
        }

    }

    void FixedUpdate()
    {
        //Color normal = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        //tilemap.color = normal;
    }
}
