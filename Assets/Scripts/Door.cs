using TMPro;
using UnityEngine;

namespace WildBall
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private TMP_Text pressF;
        [SerializeField] private Animator door1;
        [SerializeField] private Animator door2;
        [SerializeField] private GameObject ball;
        private bool trg;

        private void Start()
        {
            trg = false;
        }

        private void Update()
        {
            OnPress();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Soul>())
            {
                pressF.gameObject.SetActive(true);
                trg = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Soul>())
            {
                pressF.gameObject.SetActive(false);
                trg = false;
            }
        }

        private void OnPress()
        {
            if (trg == true)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    door1.SetTrigger(Inputs.GlobalInputVars.Play);
                    door2.SetTrigger(Inputs.GlobalInputVars.Play);
                    ball.gameObject.SetActive(true);
                }
            }
        }
    }
}
