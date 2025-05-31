using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    
    private float topBound = 15;
    private float lowerBound = -5;
    
    void Update()
    {
        if(transform.position.z > topBound)
        {
            Destroy(gameObject);
        }else if(transform.position.z < lowerBound)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }
}
