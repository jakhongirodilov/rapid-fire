using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float moveSpeed = 10f;        // Speed of the ship's movement
    private Camera mainCamera;            // Reference to the main camera

    void Start()
    {
        mainCamera = Camera.main;         // Get the main camera
    }

    void Update()
    {
        // Handle keyboard movement (WASD)
        HandleKeyboardInput();
    }

    void HandleKeyboardInput()
    {
        float moveX = Input.GetAxis("Horizontal");  // A/D or Left/Right Arrow (for x-axis)
        float moveZ = Input.GetAxis("Vertical");     // W/S or Up/Down Arrow (for z-axis)

        // Normalize movement to ensure consistent speed in all directions
        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized; // Normalize to avoid faster diagonal movement
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // Keep the ship within the camera bounds
        ClampPosition();
    }

    void ClampPosition()
    {
        // Calculate the camera bounds in world space
        float halfHeight = mainCamera.orthographicSize; // Half of the camera height
        float halfWidth = halfHeight * mainCamera.aspect; // Half of the camera width

        // Calculate the left, right, bottom, and top bounds based on camera position
        float minX = mainCamera.transform.position.x - halfWidth;
        float maxX = mainCamera.transform.position.x + halfWidth;
        float minZ = mainCamera.transform.position.z - halfHeight;
        float maxZ = mainCamera.transform.position.z + halfHeight;

        // Clamp the spaceship's position within the calculated camera bounds
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedZ = Mathf.Clamp(transform.position.z, minZ, maxZ);

        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);
    }
}
