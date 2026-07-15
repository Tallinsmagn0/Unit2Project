using UnityEngine;

public class LevelLoader : MonoBehaviour
{

    private static LevelLoader instance;
    public static LevelLoader GetInstance()
    {
        return instance;
    }
    public static int levelScore = 0;

    public Player playerPrefab;
    public Enemy enemyPrefab;

    public static void AddScore(int score)
    {
        levelScore += score;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player player = Instantiate(playerPrefab);

        Enemy enemy1 = Instantiate(enemyPrefab);
        Enemy enemy2 = Instantiate(enemyPrefab);

        Weapon gun1 = new Weapon();
        Weapon gun2 = new Weapon("Nerf gun", 1);

        EnemyType enemy1Type = EnemyType.Melee;
        EnemyType enemy2Type = new EnemyType();
        enemy2Type = EnemyType.MachineGun;

        player.weapon = gun1;
        enemy2.weapon = gun1;
        enemy2.weapon = gun1;

        Vector3 moveDirection = Vector3.right;
        Vector3 shootDirection = Vector3.left;
        player.Move(moveDirection);
        player.Shoot(shootDirection, 5);

        Debug.Log($"Weapon count is {Weapon.weaponCount}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
