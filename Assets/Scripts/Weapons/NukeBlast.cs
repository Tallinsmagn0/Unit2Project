using UnityEngine;

public class NukeBlast : MonoBehaviour
{
    [SerializeField] private float blastDuration;
    [SerializeField] private float blastRadius;

    private float timer;

    void Start()
    {
        transform.localScale = new Vector3(blastRadius, blastRadius, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        AdvanceTimer();
    }

    void AdvanceTimer()
    {
        timer += Time.deltaTime;
    }
}
