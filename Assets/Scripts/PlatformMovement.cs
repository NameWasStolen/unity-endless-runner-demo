using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private float platformMovespeed = 8f;
    private float despawnCoord = -30f; 

    // Update is called once per frame
    void Update()
    {
        // Moving the platform
        transform.position = transform.position + (Vector3.back * platformMovespeed * Time.deltaTime);


        // Despawn checking
        if (transform.position.z < despawnCoord)
        {
            Destroy(gameObject); // Destroy the platform if it goes out of bounds
        }
    }
}
