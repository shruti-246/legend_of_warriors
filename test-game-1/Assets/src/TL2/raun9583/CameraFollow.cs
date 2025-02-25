// using UnityEngine;

// public class CameraFollow : MonoBehaviour
// {
//     public Transform player; // Reference to the player's transform
//     public Vector3 offset; // Offset between camera and player

//     void Start()
//     {
//         // Set the initial offset if not set
//         if (offset == Vector3.zero)
//         {
//             offset = transform.position - player.position; // Calculate the offset
//         }
//     }

//     void LateUpdate()
//     {
//         // Update the camera position to follow the player
//         transform.position = player.position + offset;
//     }
// }



using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset; // Offset between camera and player
    public float zoomSpeed = 1f; // Speed of zooming in and out
    public float targetZoom = 10f; // Desired orthographic size for zoom

    private Camera cam; // Reference to the Camera component

    void Start()
    {
        cam = GetComponent<Camera>(); // Get the Camera component

        // Set the initial offset if not set
        if (offset == Vector3.zero)
        {
            offset = transform.position - player.position; // Calculate the offset
        }
    }

    void LateUpdate()
    {
        // Update the camera position to follow the player
        transform.position = player.position + offset;

        // Set the orthographic size for zoom
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, zoomSpeed * Time.deltaTime);
    }
}
