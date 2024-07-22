using UnityEngine;
using WildBall;

public class Bonus : MonoBehaviour
{
    [SerializeField] private ParticleSystem bonusEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Soul>())
        {
            gameObject.SetActive(false);
            bonusEffect.Play();
        }
    }
}
