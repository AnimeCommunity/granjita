using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed; // Speed of the enemy
    private Rigidbody enemyRb; // Reference to the Rigidbody component
    private GameObject player; // Reference to the player GameObject
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the enemy
        player = GameObject.Find("Player"); // Find the GameObject named "Player" in the scene
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized; // Calculate the direction towards the player
        enemyRb.AddForce(lookDirection * speed); // Move the enemy towards the player

        if(transform.position.y < -10)
        {
            Destroy(gameObject); // Destroy the enemy if it falls below a certain height
        }
    }
}
