using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    [Header("Base Movement Settings")]
    public float moveSpeed = 5f;        // Forward/backward movement
    public float rotationSpeed = 60f;   // Base rotation (turn left/right)

    [Header("Turret Aiming Settings")]
    public Transform cannonTube;        // Assign CannonTube in Inspector
    public float aimSpeed = 45f;        // Speed of aiming up/down
    public float minAimAngle = -10f;    // Minimum downward tilt
    public float maxAimAngle = 45f;     // Maximum upward tilt

    private float currentAimAngle = 0f;

    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleAiming();
    }

    void HandleMovement()
    {
        // W = forward, S = backward (local forward/back)
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.W))
            moveInput = 1f;
        else if (Input.GetKey(KeyCode.S))
            moveInput = -1f;

        // Move relative to where the cannon is facing
        Vector3 move = transform.forward * moveInput * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);
    }

    void HandleRotation()
    {
        // Rotate base left/right with arrow keys (Y-axis)
        float rotateInput = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
            rotateInput = -1f;
        else if (Input.GetKey(KeyCode.RightArrow))
            rotateInput = 1f;

        transform.Rotate(Vector3.up * rotateInput * rotationSpeed * Time.deltaTime, Space.World);
    }

    void HandleAiming()
    {
        if (cannonTube == null) return;

        // Aim up/down with arrow keys
        float aimInput = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
            aimInput = 1f;
        else if (Input.GetKey(KeyCode.DownArrow))
            aimInput = -1f;

        currentAimAngle = Mathf.Clamp(currentAimAngle + aimInput * aimSpeed * Time.deltaTime, minAimAngle, maxAimAngle);
        cannonTube.localRotation = Quaternion.Euler(-currentAimAngle, 0f, 0f);
    }
}
