using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseEscape : MonoBehaviour
{

    int toggle = 0;

    [SerializeField] GameObject pauseMenu;
    public KeyCode PauseHotkey;
    void Update()
    {
        if (UnityEngine.Input.GetKeyUp(PauseHotkey))
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
}
