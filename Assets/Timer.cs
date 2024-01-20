using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float remainingTime = 60f; // 60 seconds for 1 minute
    private bool isTimerRunning;

    void Start()
    {
        // Start the countdown timer
        isTimerRunning = true;
    }

    void Update()
    {
        if (isTimerRunning)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                UpdateTimerDisplay(remainingTime);
            }
            else
            {
                // Time is up
                remainingTime = 0;
                isTimerRunning = false;
                OnTimeUp();
            }
        }
    }

    private void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(0, timeToDisplay);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}", seconds);
    }

    private void OnTimeUp()
    {
        // Handle the "lost" condition
        Debug.Log("Time's up! You lost.");
        // Here you can add any logic you need to handle the player losing the game
    }
}
