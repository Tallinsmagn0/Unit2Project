using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _seconds;

    public string timer
    {
        get
        {
            return 
            Mathf.Round((float) _seconds / 60f).ToString()
            + " minutes and " 
            + _seconds % 60
            + " seconds";
        }

        private set { }
    }
}
