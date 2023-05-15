using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void Setup()
    {
        Invoke("activeFalse", 2f);
    }
    void activeFalse()
    {
        gameObject.SetActive(true);
    }

    public void ButtonRestart()
    {
        SceneManager.LoadScene("SampleScene");

        // Reset back to normal speed
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

    public void ButtonMainMenu()
    {
        SceneManager.LoadScene("Menu");

        // Reset back to normal speed
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

}
