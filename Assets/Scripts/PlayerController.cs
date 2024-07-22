using UnityEngine;

namespace WildBall
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        public const string HorizontalAxis = "Horizontal";
        public const string VerticalAxis = "Vertical";
        public const string Jump = "Jump";
        private Vector3 movement;
        private PlayerMovement playerMovement;
        private bool wishJump;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }
        void Update()
        {
            float horizontal = Input.GetAxis(HorizontalAxis);
            float vertical = Input.GetAxis(VerticalAxis);
            movement = new Vector3(horizontal, 0, vertical).normalized;
            wishJump |= Input.GetButtonDown(Jump);
        }

        private void FixedUpdate()
        {
            playerMovement.MoveCharacter(movement);
            playerMovement.Jump(wishJump);
            wishJump = false;
        }
    }
}