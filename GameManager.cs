using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int lives = 3;
    public int score = 0;

    void Awake()
    {
        //  solo  una instancia
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Debug.Log("Lives = " + lives + ", Score = " + score);
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score = " + score);
    }

    public void LoseLife()
    {
        lives--;
        Debug.Log("Lives = " + lives);
        if (lives <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
