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
    }

    public void ButtonMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
