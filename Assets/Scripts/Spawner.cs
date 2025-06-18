using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject stone;
    [SerializeField]
    private GameObject food;
    [SerializeField]
    private Collider spawnRegion;
    [SerializeField]
    private float stoneSpawnRate = 1f;
    [SerializeField]
    private float nextStoneSpawnTime = 0.2f;
    [SerializeField]
    private float foodSpawnRate = 1f;
    [SerializeField]
    private float nextfoodSpawnTime = 0.2f;

    private void Update()
    {
        if (Time.time >= nextStoneSpawnTime)
        {
            SpawnStone();
            nextStoneSpawnTime = Time.time + 1f / stoneSpawnRate;
        }

        if (Time.time >= nextfoodSpawnTime)
        {
            SpawnFood();
            nextfoodSpawnTime = Time.time + 1f / foodSpawnRate;
        }
    }

    private void SpawnStone()
    {
        Bounds bounds = spawnRegion.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomZ = Random.Range(bounds.max.z, bounds.min.z);

        GameObject spawnedObject = Instantiate(stone, new Vector3(randomX, 49.787f, randomZ), Quaternion.identity);
    }

    private void SpawnFood()
    {
        Bounds bounds = spawnRegion.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomZ = Random.Range(bounds.max.z, bounds.min.z);

        GameObject spawnedObject = Instantiate(food, new Vector3(randomX, 49.787f, randomZ), Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 60f), Random.Range(0f, 60f)));
    }
}
