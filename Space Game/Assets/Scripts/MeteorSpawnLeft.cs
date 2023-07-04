using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class MeteorSpawnLeft : MonoBehaviour
{
    public GameObject mermiPrefab; // Olu�turulacak mermi prefab�
    public float minSpawnInterval = 1f; // Minimum olu�turma aral��� (saniye)
    public float maxSpawnInterval = 3f; // Maksimum olu�turma aral��� (saniye)
    public float mermiSpeed = -5f; // Mermi h�z�
    public float mermiLifetime = 5f; // Mermi �mr� (saniye)

    private float nextSpawnTime; // Bir sonraki mermi olu�turma zaman�

    private void Start()
    {
        // �lk mermiyi hemen olu�turmak i�in nextSpawnTime'� g�ncelliyoruz
        SetNextSpawnTime();
    }

    private void Update()
    {
        // Zaman kontrol� yap�larak mermi olu�turulur
        if (Time.time >= nextSpawnTime)
        {
            SpawnMermi();
            SetNextSpawnTime();
        }
    }

    private void SetNextSpawnTime()
    {
        // Rastgele bir olu�turma zaman� belirleme
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void SpawnMermi()
    {
        // Mermi objesini olu�turma
        GameObject mermi = Instantiate(mermiPrefab, transform.position, Quaternion.Euler(0f, 0f, -180f));

        // Rigidbody bile�enini al
        Rigidbody2D mermiRigidbody = mermi.GetComponent<Rigidbody2D>();
        if (mermiRigidbody != null)
        {
            // Mermiye h�z ver
            mermiRigidbody.velocity = new Vector2(mermiSpeed, 0f);
            Destroy(mermi, mermiLifetime);
        }
        else
        {
            Debug.LogError("Rigidbody2D componenti bulunamad�!");
        }
    }
}


