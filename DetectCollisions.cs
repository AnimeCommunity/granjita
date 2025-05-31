using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject); // solo destruye al animal
            GameManager.Instance.LoseLife(); // Se escapo
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameManager.Instance.LoseLife(); // El jugador fue golpeado
        }
        else if (other.CompareTag("Projectile"))
        {
            Destroy(gameObject);      // Destruye al animal
            Destroy(other.gameObject); // Destruye la comida
            GameManager.Instance.AddScore(1); // Gana punto
        }
    }

}
