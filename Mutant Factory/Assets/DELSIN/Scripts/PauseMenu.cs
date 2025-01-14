using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    int toggle = 0;

    [SerializeField] GameObject pauseMenu;
    public KeyCode PauseHotkey;
    private void Update()
    {
        if (UnityEngine.Input.GetKey(PauseHotkey))
        {
            toggle += 1;
            pauseMenu.SetActive(true);
            Debug.Log("Toggle");
        }
        if (toggle >= 2)
        {
            pauseMenu.SetActive(false);
            toggle = 0;
        }
    }
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
        Debug.Log("Quitties");
        SceneManager.LoadScene("Spawn");
    }
    public void Credits()
    {

    }
}
