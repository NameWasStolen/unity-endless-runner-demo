using UnityEngine;

public class AxeSwingTrap : MonoBehaviour
{
    public float rotationRange = 45f; // Degrees to rotate, assuming axe from center
    public float rotationSpeed = 45f; // Degrees per second
    public bool isMovingRight;
    void Start()
    {
        // Set the rotation at a random angle and direction
        float startingRotation = Random.Range(0, 2 * rotationRange) - rotationRange; 
        transform.rotation = Quaternion.Euler(0f, 0f, startingRotation);
        isMovingRight = Random.Range(0, 2) == 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Get normalized rotation angle
        Vector3 currentRotation = transform.localRotation.eulerAngles; // Returns angles between 0 and 360 degrees
        if (currentRotation.z > 180f) // Normalize to -180 to 180 degrees
        {
            currentRotation.z -= 360f;
        }
        if (isMovingRight)
        {
            currentRotation.z += rotationSpeed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(currentRotation);
            if (currentRotation.z >= rotationRange)
            {
                isMovingRight = false;
            }
        }
        else
        {
            currentRotation.z -= rotationSpeed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(currentRotation);
            if (currentRotation.z <= -rotationRange)
            {
                isMovingRight = true;
            }
        }
    }
}
