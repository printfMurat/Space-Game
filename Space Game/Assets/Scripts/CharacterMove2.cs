using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMove2 : MonoBehaviour
{


   
        public float MoveSpeed = 5f;
        public AudioSource SpaceShip;
        public Rigidbody2D rb;

        private bool isMovingUp = false;
        private bool isMovingDown = false;

        void FixedUpdate()
        {
            float verticalMovement = 0f;

            if (isMovingUp)
            {
                verticalMovement = 1f;
                SpaceShip.pitch = 1f;
            }
            else if (isMovingDown)
            {
                verticalMovement = -1f;
                SpaceShip.pitch = -1f;
            }
            else
            {
                SpaceShip.pitch = 1f;
            }

            Vector2 movement = new Vector2(0, verticalMovement);
            rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.pointerEnter.name == "UpButton") // UpButton yerine yukarý butonun adýný yazýn
            {
                isMovingUp = true;
            }
            else if (eventData.pointerEnter.name == "DownButton") // DownButton yerine aþaðý butonun adýný yazýn
            {
                isMovingDown = true;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isMovingUp = false;
            isMovingDown = false;
        }
    
}