using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

public class CharackerMove : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public AudioSource SpaceShip;
    public Rigidbody2D rb;
    Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
        movement.y = Input.GetAxisRaw("Vertical");
       

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
        if (movement.y > 0)
        {
            SpaceShip.pitch = 1f;
        }
        else if (movement.y < 0)
        {
            SpaceShip.pitch = -1f;
        }
        else
        {
            SpaceShip.pitch = 1f;
        }
    }
}
