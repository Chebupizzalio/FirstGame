using System.Runtime.CompilerServices;
using UnityEditorInternal;
using UnityEngine;

namespace WildBall
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        public const string HorizontalAxis = "Horizontal";
        public const string VerticalAxis = "Vertical";
        public const string Jump = "Jump";
        public const string Cancel = "Cancel";
        private Vector3 movement;
        private PlayerMovement playerMovement;
        private Menu stateMachine;
        private bool wishJump;
        private bool esc;

        private void Awake()
        {
            stateMachine = GetComponent<Menu>();
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