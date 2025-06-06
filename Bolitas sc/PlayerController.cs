using System.Collections;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    
    private Rigidbody playerRb; // Reference to the Rigidbody component
    public float speed = 5.0f; // Speed of the player
    private GameObject focalPoint; // Reference to the focal point (not used in this script, but can be useful for camera control)
    public bool hasPowerup; // Boolean to check if the player has a power-up
    private float powerupStrength = 15.0f; // Strength of the power-up effect
    public GameObject powerupIndicator; // Reference to the power-up indicator GameObject
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the player
        focalPoint = GameObject.Find("Focal Point"); // Find the GameObject named "FocalPoint" in the scene
    }

    // Update is called once per frame
    void Update()
    {
        float fowardInput = Input.GetAxis("Vertical"); // Get vertical input (W/S or Up/Down arrows)
        playerRb.AddForce(focalPoint.transform.forward * fowardInput * speed); // Move the player forward or backward based on input

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0); // Update the position of the power-up indicator to be slightly below the player
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup")) // Check if the collided object has the tag "Powerup"
        {
            hasPowerup = true; // Set hasPowerup to true
            powerupIndicator.SetActive(true); // Activate the power-up indicator
            Destroy(other.gameObject); // Destroy the power-up object
            Debug.Log("Powerup collected!"); // Log a message to the console
            StartCoroutine(PowerupCooldown()); // Start the power-up cooldown coroutine
        }
    }

    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(7); // Wait for 7 seconds
        hasPowerup = false; // Set hasPowerup to false after the cooldown
        Debug.Log("Powerup ended!"); // Log a message to the console
        powerupIndicator.SetActive(false); // Deactivate the power-up indicator
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup) // Check if the collided object is an enemy and the player has a power-up
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>(); // Get the Rigidbody component of the enemy
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position; // Calculate the direction away from the player
            
            
            Debug.Log("Colleded with " + collision.gameObject.name + " with powerup set to " + hasPowerup); // Log a message to the console

            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse); // Apply a force to the enemy away from the player
        }
    }
}
