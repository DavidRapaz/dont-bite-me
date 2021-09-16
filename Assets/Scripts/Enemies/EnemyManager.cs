using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Public Variables
    public GameObject enemies_prefab;
    public float spawnTime = 2f;

    // Private Variables
    private GameObject[] spawnPoints;
    private LevelManager gameStateManager;
    private System.Random r = new System.Random();

    // Use this for initialization
    void Start()
    {
        gameStateManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        spawnPoints      = GameObject.FindGameObjectsWithTag("SpawnPoint");

        SpawnFirstCouple();

        Invoke("SpawnEnemy", spawnTime);
    }
    
    void SpawnFirstCouple ()
    {
        int randomSpawn1 = r.Next(0, spawnPoints.Length);
        int randomSpawn2 = r.Next(0, spawnPoints.Length);

        while (randomSpawn2 == randomSpawn1)
            randomSpawn2 = r.Next(0, spawnPoints.Length);

        Instantiate(enemies_prefab, spawnPoints[randomSpawn1].transform.position, spawnPoints[randomSpawn1].transform.rotation, spawnPoints[randomSpawn1].transform);
        Instantiate(enemies_prefab, spawnPoints[randomSpawn2].transform.position, spawnPoints[randomSpawn2].transform.rotation, spawnPoints[randomSpawn2].transform);
    }

    /*
     * Used to spawn enemies randomly,
     * using gameobjects as spawn points.
     **/
    void SpawnEnemy()
    {
        int randomSpawn1 = r.Next(0, spawnPoints.Length);
        int randomSpawn2 = r.Next(0, spawnPoints.Length);

        while (randomSpawn2 == randomSpawn1)
            randomSpawn2 = r.Next(0, spawnPoints.Length);

        if (gameStateManager.timeValue > 0f)
        {
            if (spawnPoints[randomSpawn1].transform.childCount == 0)
                Instantiate(enemies_prefab, spawnPoints[randomSpawn1].transform.position, spawnPoints[randomSpawn1].transform.rotation, spawnPoints[randomSpawn1].transform);

            if (spawnPoints[randomSpawn2].transform.childCount == 0)
                Instantiate(enemies_prefab, spawnPoints[randomSpawn2].transform.position, spawnPoints[randomSpawn2].transform.rotation, spawnPoints[randomSpawn2].transform);
            
            Invoke("SpawnEnemy", spawnTime);
        }
    }
}
