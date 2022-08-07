using TMPro;
using UnityEngine;

// Resource used: https://www.youtube.com/watch?v=HmHPJL-OcQE&ab_channel=GameDevBeginner

public class Timer : MonoBehaviour
{
    [SerializeField] float timeValue;
    public TextMeshProUGUI timeText;
    
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
        
        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        
        timeText.text = $"{minutes:00}:{seconds:00}"; // Same as: -> string.Format("{0:00}:{1:00}", minutes, seconds)
    }
}
