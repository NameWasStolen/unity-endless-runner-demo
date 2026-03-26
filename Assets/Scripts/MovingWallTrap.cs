using UnityEngine;

public class MovingWallTrap : MonoBehaviour
{
    public float wallSpeed = 6f;
    public float wallRange = 6f; // Range of movement (from the left, to the right)
    public bool isMovingRight;

    void Start()
    {
        // Start at a random position within the range
        float randomX = Random.Range(0, wallRange);
        transform.position += Vector3.right * randomX;
        // Start at random direction
        isMovingRight = Random.Range(0, 2) == 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingRight)
        {
            transform.position += Vector3.right * wallSpeed * Time.deltaTime;
            if (transform.position.x >= wallRange)
            {
                isMovingRight = false;
            }
        }
        else
        {
            transform.position -= Vector3.right * wallSpeed * Time.deltaTime;
            if (transform.position.x <= -wallRange)
            {
                isMovingRight = true;
            }
        }
    }
}
