using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{

    // ------ Singleton Setup ------
    private static GameManager instance;
    public static GameManager GetInstance()
    {
        return instance;
    }

    void SetSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    // ------ End Singleton Setup ------

    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private GameObject exploderEnemyPrefab;
    [SerializeField] private GameObject MachineGunEnemyPrefab;
    [SerializeField] private GameObject meleeEnemyPrefab;
    [SerializeField] private GameObject shooterEnemyPrefab;
    [SerializeField] private float bulletLifetime;
    [SerializeField] private float spawnInterval;
    [SerializeField] private float spawnRadius = 10f;

    private Player player;
    private Dictionary<EnemyType, GameObject> enemyTypeToPrefab = new Dictionary<EnemyType, GameObject>();
    private float spawnTimer;

    void Awake()
    {
        SetSingleton();
        FindPlayer();
        SetEnemyPrefabDictionary();
    }

    void Start()
    {

        ResetTimer();
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer < spawnInterval)
        {
            AdvanceTimer();
        } else
        {
            SpawnEnemy();
            ResetTimer();
        }
    }

    void SetEnemyPrefabDictionary()
    {
        if (exploderEnemyPrefab != null) {
           enemyTypeToPrefab[EnemyType.Exploder] = exploderEnemyPrefab; 
        }
        if (MachineGunEnemyPrefab != null) {
           enemyTypeToPrefab[EnemyType.MachineGun] = MachineGunEnemyPrefab;
        }
        if (meleeEnemyPrefab != null) {
           enemyTypeToPrefab[EnemyType.Melee] = meleeEnemyPrefab; 
        }
        if (shooterEnemyPrefab != null) {
           enemyTypeToPrefab[EnemyType.Shooter] = shooterEnemyPrefab;
        }
    }

    void SpawnEnemy()
    {
        int randomEnemyIndex = Random.Range(0, enemyTypeToPrefab.Count);
        GameObject randomEnemyPrefab = enemyTypeToPrefab.ElementAt(randomEnemyIndex).Value;
        Vector2 spawnPosition = Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(randomEnemyPrefab, spawnPosition, Quaternion.identity);
    }

    void ResetTimer()
    {
        spawnTimer = 0;
    }

    void AdvanceTimer()
    {
        spawnTimer += Time.deltaTime;
    }

    public Player GetPlayer()
    {
        return player;
    }

    private void FindPlayer()
    {
        player = FindFirstObjectByType<Player>();
    }

    public ScoreManager GetScoreManager()
    {
        return scoreManager;
    }

    public float GetBulletLifetime()
    {
        return bulletLifetime;
    }
}
