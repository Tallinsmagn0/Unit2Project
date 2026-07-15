using UnityEngine;

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

    void Awake()
    {
        SetSingleton();
    }
    // ------ End Singleton Setup ------

    [SerializeField] private ScoreManager scoreManager;
    private Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
