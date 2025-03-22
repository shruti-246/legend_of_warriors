using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f; // Set a default speed
    public Tilemap tilemap; // Assign this in the Inspector

    private Vector3Int currentTilePosition;

    void Start()
    {
        if (tilemap == null)
        {
            Debug.LogError("Tilemap is not assigned! Please assign the Tilemap in the Inspector.");
            return;
        }
        // Debug.LogError("tile map is assigned.");

        currentTilePosition = tilemap.WorldToCell(transform.position); // Initialize to the player's starting position
    }

    void Update()
{
    float horizontalInput = Input.GetAxisRaw("Horizontal");
    float verticalInput = Input.GetAxisRaw("Vertical");

    Debug.Log($"Horizontal Input: {horizontalInput}, Vertical Input: {verticalInput}");

    // Calculate target tile position
    Vector3Int targetTile = currentTilePosition + new Vector3Int((int)horizontalInput, (int)verticalInput, 0);

    // Check if target tile is valid (not blocked)
    if (CanMoveToTile(targetTile))
    {
        Debug.Log($"Moving to tile: {targetTile}");
        // Move player to target tile position
        transform.position = tilemap.GetCellCenterWorld(targetTile);
        currentTilePosition = targetTile;
    }
    else
    {
        Debug.Log("Cannot move to that tile.");
    }
}


    private bool CanMoveToTile(Vector3Int tilePosition)
    {
        if (tilemap == null) return false;

        // Check if the tile is walkable (null tiles are considered walkable)
        TileBase tile = tilemap.GetTile(tilePosition);
        return tile == null; // Assuming null tiles are walkable
    }
}
