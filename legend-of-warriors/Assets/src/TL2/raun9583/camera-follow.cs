using UnityEngine;

public class CameraFollowNew : MonoBehaviour
{
    public Transform target; // Reference to the player
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Keep Z at -10f for 2D camera

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
