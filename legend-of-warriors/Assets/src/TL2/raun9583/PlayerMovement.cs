// using UnityEngine;
// using UnityEngine.Tilemaps;
// using System.Collections;

// public class PlayerMovement : MonoBehaviour
// {
//     public float moveSpeed = 5f; // Adjust movement speed
//     public Tilemap tilemap; // Assign in Inspector
//     public TileBase[] walkableTiles; // Drag & drop walkable tiles in the Inspector

//     private Vector3Int currentTilePosition;
//     private bool isMoving = false;

//     void Start()
//     {
//         if (tilemap == null)
//         {
//             Debug.LogError("Tilemap is not assigned! Please assign the Tilemap in the Inspector.");
//             return;
//         }

//         currentTilePosition = tilemap.WorldToCell(transform.position);
//         transform.position = tilemap.GetCellCenterWorld(currentTilePosition);
//     }

//     void Update()
//     {
//         if (isMoving) return; // Prevent new movement while already moving

//         int horizontalInput = (int)Input.GetAxisRaw("Horizontal");
//         int verticalInput = (int)Input.GetAxisRaw("Vertical");

//         if (horizontalInput != 0)
//             verticalInput = 0; // Prioritize horizontal movement

//         if (horizontalInput != 0 || verticalInput != 0)
//         {
//             Vector3Int targetTile = currentTilePosition + new Vector3Int(horizontalInput, verticalInput, 0);

//             if (CanMoveToTile(targetTile))
//             {
//                 StartCoroutine(MoveToTile(targetTile));
//             }
//             else
//             {
//                 Debug.Log("Cannot move to that tile.");
//             }
//         }
//     }

//     private IEnumerator MoveToTile(Vector3Int targetTile)
//     {
//         isMoving = true;

//         Vector3 startPos = transform.position;
//         Vector3 endPos = tilemap.GetCellCenterWorld(targetTile);
//         float elapsedTime = 0f;

//         while (elapsedTime < 1f / moveSpeed)
//         {
//             transform.position = Vector3.Lerp(startPos, endPos, elapsedTime * moveSpeed);
//             elapsedTime += Time.deltaTime;
//             yield return null;
//         }

//         transform.position = endPos;
//         currentTilePosition = targetTile;
//         isMoving = false;
//     }

//     private bool CanMoveToTile(Vector3Int tilePosition)
//     {
//         if (tilemap == null) return false;

//         TileBase tile = tilemap.GetTile(tilePosition);

//         if (tile == null) return true; // If no tile is present, assume walkable

//         foreach (TileBase walkableTile in walkableTiles)
//         {
//             if (tile == walkableTile)
//                 return true; // Tile is in the walkable list
//         }

//         return false; // Tile is not walkable
//     }
// }




using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 50f; // Movement speed
    public Tilemap tilemap; // Assign your Tilemap
    public TileBase[] walkableTiles; // Drag walkable tiles here

    private Vector3Int currentTilePosition;
    private bool isMoving = false;

    void Start()
    {
        if (tilemap == null)
        {
            Debug.LogError("Tilemap not assigned!");
            return;
        }

        currentTilePosition = tilemap.WorldToCell(transform.position);
        transform.position = tilemap.GetCellCenterWorld(currentTilePosition);

        Debug.Log("Player initialized at tile: " + currentTilePosition);
    }

    void Update()
    {
        if (isMoving) return;

        int horizontalInput = 0;
        int verticalInput = 0;

        // Using WASD keys directly
        if (Input.GetKeyDown(KeyCode.W)) { verticalInput = 1; Debug.Log("W Pressed"); }
        if (Input.GetKeyDown(KeyCode.S)) { verticalInput = -1; Debug.Log("S Pressed"); }
        if (Input.GetKeyDown(KeyCode.A)) { horizontalInput = -1; Debug.Log("A Pressed"); }
        if (Input.GetKeyDown(KeyCode.D)) { horizontalInput = 1; Debug.Log("D Pressed"); }

        // Prioritize horizontal movement over vertical
        if (horizontalInput != 0)
            verticalInput = 0;

        if (horizontalInput != 0 || verticalInput != 0)
        {
            Vector3Int direction = new Vector3Int(horizontalInput, verticalInput, 0);
            Vector3Int targetTile = currentTilePosition + direction;

            Debug.Log("Trying to move to: " + targetTile);

            if (CanMoveToTile(targetTile))
            {
                StartCoroutine(MoveToTile(targetTile));
            }
            else
            {
                Debug.Log("Blocked tile: " + targetTile);
            }
        }
    }

    private IEnumerator MoveToTile(Vector3Int targetTile)
    {
        isMoving = true;

        Vector3 startPos = transform.position;
        Vector3 endPos = tilemap.GetCellCenterWorld(targetTile);
        float elapsedTime = 0f;

        Debug.Log("Moving from " + currentTilePosition + " to " + targetTile);

        while (elapsedTime < 1f / moveSpeed)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsedTime * moveSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;
        currentTilePosition = targetTile;
        isMoving = false;

        Debug.Log("Arrived at tile: " + currentTilePosition);
    }

    private bool CanMoveToTile(Vector3Int tilePosition)
    {
        if (tilemap == null) return false;

        TileBase tile = tilemap.GetTile(tilePosition);

        if (tile == null) 
        {
            Debug.Log("No tile at " + tilePosition + ", assuming walkable.");
            return true;
        }

        foreach (TileBase walkableTile in walkableTiles)
        {
            if (tile == walkableTile)
            {
                Debug.Log("Tile at " + tilePosition + " is walkable.");
                return true;
            }
        }

        Debug.Log("Tile at " + tilePosition + " is not walkable.");
        return false;
    }
}





