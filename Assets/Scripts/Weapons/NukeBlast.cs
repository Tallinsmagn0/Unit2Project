using UnityEngine;

public class NukeBlast : MonoBehaviour
{
    [SerializeField] private float blastDuration;
    [SerializeField] private float blastRadius;

    private float timer;
    private SpriteRenderer sr;
    private Color startingColor;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        startingColor = sr.color;
        transform.localScale = new Vector3(blastRadius, blastRadius, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        AdvanceTimer();
        UpdateTransparency();

        if (timer > blastDuration)
        {
            Destroy(gameObject);
        }
    }

    void AdvanceTimer()
    {
        timer += Time.deltaTime;
    }

    void UpdateTransparency()
    {
        Color newColor = startingColor;
        float alpha = startingColor.a * (1 - (timer / blastDuration));
        newColor.a = alpha;
        sr.color = newColor;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            enemy.Defeated();
        }
        if (collider.gameObject.CompareTag("Pickup"))
        {
            Debug.Log("HIT PICKUP");
            Pickup pickup = collider.gameObject.GetComponent<Pickup>();
            pickup.GetDamage(0);
        }
    }
}
