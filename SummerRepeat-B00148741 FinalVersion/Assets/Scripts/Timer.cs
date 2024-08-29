using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI ActualTxt;

    public float actualTime;
    private bool isTimeRunning = false;

    void Start()
    {
        // Initialize the timer (e.g., 2 minutes = 120 seconds)
     
        isTimeRunning = true;
    }

    void Update()
    {
        if (isTimeRunning)
        {
            if (actualTime > 0)
            {
                actualTime -= Time.deltaTime;
                UpdateTimeEverySecond();
            }
            else
            {
                actualTime = 0;
                isTimeRunning = false;
                UpdateTimeEverySecond();
                // Timer has run out
                // Add additional actions here if needed
            }
        }
    }

    void UpdateTimeEverySecond()
    {
        int minutes = Mathf.FloorToInt(actualTime / 60);
        int seconds = Mathf.FloorToInt(actualTime % 60);

        ActualTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
