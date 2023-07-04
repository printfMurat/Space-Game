using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Slider timerSlider; // Slider nesnesi

    private float currentTime; // Ge�erli zaman
    public float maxTime = 40f; // Maksimum s�re (1 dakika)

    private bool isTimerRunning = false; // Saya� �al���yor mu?
    public GameObject GameOverPanel;

    private void Start()
    {
        currentTime = maxTime;
        timerSlider.maxValue = maxTime;
        timerSlider.value = currentTime;
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            if (currentTime > 0f)
            {
                currentTime -= Time.deltaTime;
                timerSlider.value = currentTime;
            }
            else
            {
                GameOverPanel.SetActive(true);
            }
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        currentTime = maxTime;
        timerSlider.value = currentTime;
    }
    
}
