using UnityEngine;

public class Rocket : MonoBehaviour
{
    
    private Transform target; // Target to which the rocket will move
    public float speed = 10f; // Speed of the rocket
    public float strength = 10f; // Strength of the rocket's force
    private Rigidbody rocketRb; // Reference to the Rigidbody component of the rocket
    private float lifeTime = 5f; // Lifetime of the rocket before it is destroyed
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 moveDirection = (target.transform.position - transform.position).normalized; // Calculate the direction towards the target
            transform.position += moveDirection * speed * Time.deltaTime; // Move the rocket towards the target
            transform.LookAt(target); // Rotate the rocket to face the target
        }
    }

    public void Shoot(Transform target)
    {
        this.target = target; // Set the target for the rocket
        Destroy(gameObject, lifeTime); // Destroy the rocket after its lifetime expires
    }

    void OnCollisionEnter(Collision col)
    {
        if (target != null)
        {
            if (col.gameObject.CompareTag(target.tag))
            {
                Rigidbody targetRigidbody = col.gameObject.GetComponent<Rigidbody>();
                Vector3 away = -col.contacts[0].normal;
                targetRigidbody.AddForce(away * strength, ForceMode.Impulse);
                Destroy(gameObject);
            }
        }
    }

}
