using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class MeteorSpawnLeft : MonoBehaviour
{
    public GameObject mermiPrefab; // Oluþturulacak mermi prefabý
    public float minSpawnInterval = 1f; // Minimum oluþturma aralýðý (saniye)
    public float maxSpawnInterval = 3f; // Maksimum oluþturma aralýðý (saniye)
    public float mermiSpeed = -5f; // Mermi hýzý
    public float mermiLifetime = 5f; // Mermi ömrü (saniye)

    private float nextSpawnTime; // Bir sonraki mermi oluþturma zamaný

    private void Start()
    {
        // Ýlk mermiyi hemen oluþturmak için nextSpawnTime'ý güncelliyoruz
        SetNextSpawnTime();
    }

    private void Update()
    {
        // Zaman kontrolü yapýlarak mermi oluþturulur
        if (Time.time >= nextSpawnTime)
        {
            SpawnMermi();
            SetNextSpawnTime();
        }
    }

    private void SetNextSpawnTime()
    {
        // Rastgele bir oluþturma zamaný belirleme
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void SpawnMermi()
    {
        // Mermi objesini oluþturma
        GameObject mermi = Instantiate(mermiPrefab, transform.position, Quaternion.Euler(0f, 0f, -180f));

        // Rigidbody bileþenini al
        Rigidbody2D mermiRigidbody = mermi.GetComponent<Rigidbody2D>();
        if (mermiRigidbody != null)
        {
            // Mermiye hýz ver
            mermiRigidbody.velocity = new Vector2(mermiSpeed, 0f);
            Destroy(mermi, mermiLifetime);
        }
        else
        {
            Debug.LogError("Rigidbody2D componenti bulunamadý!");
        }
    }
}


