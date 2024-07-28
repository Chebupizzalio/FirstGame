using System;
using UnityEngine;

namespace WildBall
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Range(0, 50)] private float speed = 3.0f;
        [SerializeField, Range(0, 50)] private float forse = 3.0f;
        private Rigidbody playerRigidvody;
        public static bool Grounded;

        private void Awake()
        {
            playerRigidvody = GetComponent<Rigidbody>();
        }

        public void MoveCharacter(Vector3 movement)
        {
            if (Grounded)
            {
                playerRigidvody.AddForce(movement * speed);
            }
            else
            {
                playerRigidvody.AddForce(movement * 0);
            }
        }

        public void Jump(bool wishJump)
        {
            if (wishJump & Grounded)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 0) * forse);
            }
        }

        public void OnCollisionStay(Collision collision)
        {
            if(collision.collider.CompareTag("Ground"))
            {
                Grounded = true;
            }
            
        }

        public void OnCollisionExit(Collision collision)
        {
            if(collision.collider.CompareTag("Ground"))
            {
                Grounded = false;
            }
        }
    }
}