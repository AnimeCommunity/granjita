using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject[ ] animalPrefabs;
    
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;

    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    private float leftSpawnZRange = 15;
    private float leftSpawnX = -25;
    private float rightSpawnX = 25;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }



    void SpawnRandomAnimal()
    {
        /*int spawnLugar = Random.Range(0, 3);
        }*/

        int side = Random.Range(0, 3);
        Vector3 spawnPos = Vector3.zero;
        Quaternion spawnRot = Quaternion.identity;

        int animalIndex = Random.Range(0, animalPrefabs.Length);

        if (side == 0)
        {
            // Frontal (Z+)
            spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            spawnRot = animalPrefabs[animalIndex].transform.rotation;
        }
        else if (side == 1)
        {
            // Izquierda (X-)
            spawnPos = new Vector3(leftSpawnX, 0, Random.Range(0, leftSpawnZRange));
            spawnRot = Quaternion.Euler(0, 90, 0); // mira hacia la derecha
        }
        else if (side == 2)
        {
            // Derecha (X+)
            spawnPos = new Vector3(rightSpawnX, 0, Random.Range(0, leftSpawnZRange));
            spawnRot = Quaternion.Euler(0, -90, 0); // mira hacia la izquierda
        }

        Instantiate(animalPrefabs[animalIndex], spawnPos, spawnRot);
        //Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
