using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectedLevel : MonoBehaviour
{
    [SerializeField] private int level;
    public void OnSelected()
    {
        SceneManager.LoadScene(level);
        Time.timeScale = 1.0f;
    }

    public void OnNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Time.timeScale = 1.0f;
    }
    public void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
