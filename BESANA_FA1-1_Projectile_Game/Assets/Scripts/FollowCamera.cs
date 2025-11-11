using UnityEngine;

public class CameraFollowBehind : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; // Cannon root

    [Header("Camera Offset")]
    public Vector3 offset = new Vector3(0f, 3f, -6f); // Behind & above cannon
    public float followSpeed = 10f;                   // Smooth follow speed

    void LateUpdate()
    {
        if (target == null) return;

        // Desired position: behind the cannon using its forward direction
        Vector3 desiredPosition = target.position + target.rotation * offset;

        // Smoothly move the camera to the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Look in the same direction the cannon is facing
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation(target.forward, Vector3.up),
            followSpeed * Time.deltaTime
        );
    }
}
