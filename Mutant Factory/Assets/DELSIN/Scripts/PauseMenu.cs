using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void Pauses()
    {
        pauseMenu.SetActive(true);
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
    }
    public void Home()
    {
        SceneManager.LoadScene("Spawn");
    }
    public void Settings()
    {

    }
    public void Quit()
    {

    }
    public void Credits()
    {

    }
}
