using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody playerRigidBody;
    public float jumpStrength = 6;
    public float moveSpeed = 3;
    public bool isGrounded = false;
    private float groundCheckDistance = 0.5f; 
    public bool isPlayerAlive = true;
    public LogicManager logicManager; // Reference to the LogicManager script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Update values
        isGrounded = playerIsGrounded(); // Check if the player is grounded

        // Handling User Inputs
        if (isPlayerAlive) // Player is dead, no input allowed
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Jumping
            {
                playerRigidBody.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
            }
            else if (Input.GetKey(KeyCode.LeftArrow)) // Move Left
            {
                Vector3 playerCurrVelocity = playerRigidBody.linearVelocity;
                playerCurrVelocity.x = -moveSpeed; 
                playerRigidBody.linearVelocity = playerCurrVelocity; 
            } 
            else if (Input.GetKey(KeyCode.RightArrow)) // Move Right
            {
                Vector3 playerCurrVelocity = playerRigidBody.linearVelocity; 
                playerCurrVelocity.x = moveSpeed; 
                playerRigidBody.linearVelocity = playerCurrVelocity; 
            } else // No horizontal movement input
            {
                Vector3 playerCurrVelocity = playerRigidBody.linearVelocity; 
                playerCurrVelocity.x = 0; 
                playerRigidBody.linearVelocity = playerCurrVelocity; 
            }   
        }
    }

    // Check if grounded
    private bool playerIsGrounded()
    {
        bool groundedCheck = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);
        return groundedCheck;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trap")) // Player got hit by trap. Game over
        {
            isPlayerAlive = false;
            logicManager.gameOver();
            this.gameObject.SetActive(false); // Hide player object
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PointTrigger")) // Player got a point
        {
            logicManager.addScore(); 
            Debug.Log("Player got a point!");
        }
    }
}
