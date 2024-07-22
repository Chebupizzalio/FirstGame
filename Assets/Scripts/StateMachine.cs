using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace WildBall
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameObject FirstScreen;
        [SerializeField] private GameObject SecondScreen;
        [SerializeField] private ParticleSystem DeadEffect;
        private GameObject currentScreen;

        private void Start()
        {
            FirstScreen.SetActive(true);
            currentScreen = FirstScreen;
        }

        public void ChangeState(GameObject state)
        {
            if (currentScreen != null)
            {
                currentScreen.SetActive(false);
                state.SetActive(true);
                currentScreen = state;
            }
        }

        public void OnPause(GameObject state)
        {

            if (currentScreen != null)
            {
                currentScreen.SetActive(false);
                state.SetActive(true);
                currentScreen = state;
                Time.timeScale = 0f;
            }
        }

        public void OnContinue(GameObject state)
        {
            if (currentScreen != null)
            {
                currentScreen.SetActive(false);
                state.SetActive(true);
                currentScreen = state;
                Time.timeScale = 1f;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Soul>())
            {
                currentScreen.SetActive(false);
                SecondScreen.SetActive(true);
                currentScreen = SecondScreen;
                Time.timeScale = 1;
                if (currentScreen.GetComponent<Finish>())
                {
                    other.gameObject.GetComponent<PlayerController>().enabled = false;
                }
                else
                {
                    other.gameObject.SetActive(false);
                    Instantiate(DeadEffect, other.transform.position, other.transform.rotation);
                }
                
            }
        }
    }
}
