using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }
    public void settings()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Is this working: Settings");
    }
    public void start()
    {
        SceneManager.LoadScene("SpawnTrue");
        Debug.Log("Is this working: Spawn");
    }
    public void quit()
    {
        Application.Quit();
        Debug.Log("Is this working: Quit");
    }
}
