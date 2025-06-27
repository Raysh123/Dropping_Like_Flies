using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private float phaseTwo = 7f;
    [SerializeField]
    private float phaseThree = 14f;

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
    [SerializeField]
    private float leafSpawnRate = 1f;
    [SerializeField]
    private float nextleafSpawnTime = 0.2f;
    [SerializeField]
    private float dropSpawnRate = 1f;
    [SerializeField]
    private float nextdropSpawnTime = 0.2f;

    private float scale;
    [SerializeField]
    private float scale1;
    [SerializeField]
    private float scale2;
    private ScoreManager scoreManager;
    [SerializeField]
    private float foodScale;

    private void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
        scale = Random.Range(scale1, scale2);
    }

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

        if (Time.time >= nextleafSpawnTime && scoreManager.Score >= phaseTwo)
        {
            SpawnLeaf();
            //Debug.Log("Leaf");
            nextleafSpawnTime = Time.time + 1f / leafSpawnRate;
        }

        else if (Time.time >= nextdropSpawnTime && scoreManager.Score >= phaseThree)
        {
            SpawnDrop();
            //Debug.Log("Drop");
            nextdropSpawnTime = Time.time + 1f / dropSpawnRate;
        }
    }

    private void SpawnStone()
    {
        Bounds bounds = spawnRegion.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomZ = Random.Range(bounds.max.z, bounds.min.z);

        GameObject spawnedObject = ObjectPool.sharedInstance.GetPooledObject();
        if (spawnedObject != null)
        {
            spawnedObject.transform.position = new Vector3(randomX, 49.787f, randomZ);
            spawnedObject.transform.rotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 60f), Random.Range(0f, 60f));
            spawnedObject.transform.localScale = new Vector3(scale, scale, scale);  
            spawnedObject.SetActive(true);
        }
    }
    private void SpawnLeaf()
    {
        Bounds bounds = spawnRegion.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomZ = Random.Range(bounds.max.z, bounds.min.z);

        GameObject spawnedObject = ObjectPool.sharedInstance.GetPooledLeaf();
        if (spawnedObject != null)
        {
            spawnedObject.transform.position = new Vector3(randomX, 49.787f, randomZ);
            spawnedObject.transform.rotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 60f), Random.Range(0f, 60f));
            spawnedObject.transform.localScale = new Vector3(scale, scale, scale);  
            spawnedObject.SetActive(true);
        }
    }

    int currentDropIndex;

    private void SpawnDrop()
    {
        currentDropIndex++;
        Bounds bounds = spawnRegion.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomZ = Random.Range(bounds.max.z, bounds.min.z);

        GameObject spawnedObject = ObjectPool.sharedInstance.GetPooledDrops();
        if (spawnedObject != null)
        {
            spawnedObject.transform.position = new Vector3(randomX, 49.787f, randomZ);
            spawnedObject.transform.rotation = Quaternion.identity;
            spawnedObject.transform.localScale = new Vector3(scale, scale, scale);  
            spawnedObject.SetActive(true);
            spawnedObject.name = $"Drop {currentDropIndex}";
        }
    }

    private void SpawnFood()
    {
        Bounds bounds = spawnRegion.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomZ = Random.Range(bounds.max.z, bounds.min.z);

        GameObject spawnedObject = ObjectPool.sharedInstance.GetPooledFoods();
        if (spawnedObject != null)
        {
            spawnedObject.transform.position = new Vector3(randomX, 49.787f, randomZ);
            spawnedObject.transform.rotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 60f), Random.Range(0f, 60f));
            spawnedObject.transform.localScale = new Vector3(foodScale, foodScale, foodScale);
            spawnedObject.SetActive(true);
        }
            
            //Instantiate(food, new Vector3(randomX, 49.787f, randomZ), Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 60f), Random.Range(0f, 60f)));
    }
}
