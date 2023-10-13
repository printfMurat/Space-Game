using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class CharacterControl : MonoBehaviour
{

    public Transform Player;
    public Transform[] CheckPoints;
    public float songSpeedIncrease = 0.15f;
    public int CurrentCheckpoint = 0;

    
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI IngameScoreText;

    public AudioSource kapat1;
    public AudioSource kapat2;
    public AudioSource DeathAudio;
    public AudioSource LifeAudio;
    public AudioSource Space;



    public GameObject GameOverPanel;
    public GameObject BackButton;
   

    public Transform spawnPoint;
    public int maxHealth = 3;
    private int currentHealth;
    private int score = 0;







    public Slider timerSlider; // Slider nesnesi

    private float currentTime; // Geçerli zaman
    public float maxTime = 40f; // Maksimum süre (1 dakika)

    private bool isTimerRunning = false; // Sayaç çalýþýyor mu?



    private void Start()
    {
        currentHealth = maxHealth;
        ResetCharacter();
        GameOverPanel.SetActive(false);

        currentTime = maxTime;
        timerSlider.maxValue = maxTime;
        timerSlider.value = currentTime;

        IngameScoreText.text = "Score : 0";

        CurrentCheckpoint = 0;




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
                DestroyCharacter();
            }
        }
        HealthText.text = currentHealth.ToString();




        Vector3 playerPosition = Player.position;
        playerPosition.y = 0;
        playerPosition = Player.position;

        // Oyuncu objesi, þu anki bölümün yüksekliðinin üzerine çýktýðýnda bir sonraki bölüme geçer
        if (Player.position.y >= CheckPoints[CurrentCheckpoint].position.y)
        {
            CurrentCheckpoint++;

           
            if (CurrentCheckpoint >= CheckPoints.Length)
            {
                enabled = false;
                return;
            }

            // Þarký hýzýný artýr
            
           Space.pitch += songSpeedIncrease;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Çarpýþma var");
            currentHealth--;
            if (currentHealth <= 0)
            {
                DestroyCharacter();
            }
            else
            {
                ResetCharacter();
                DeathAudio.Play();
            }
        }

        else if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Finish");
            score++;
            IngameScoreText.text = "Score : " + score.ToString();
            ResetCharacter();


        }
        else if (collision.gameObject.CompareTag("Spotify"))
        {
            LifeAudio.Play();
            StopTimer();
            StartTimer();
            Destroy(collision.gameObject);
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

    private void ResetCharacter()
    {

        transform.position = spawnPoint.position;
        CurrentCheckpoint = 0;
    }

    private void DestroyCharacter()
    {
        kapat1.enabled = false;
        kapat2.enabled = false;
        DeathAudio.Play();
        Destroy(gameObject);
        GameOverPanel.SetActive(true);
        BackButton.SetActive(false);
        ScoreText.text = "Your Score is " + score.ToString();
        timerSlider.gameObject.SetActive(false);
    }
}

