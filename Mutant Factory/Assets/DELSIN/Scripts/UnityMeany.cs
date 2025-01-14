using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityMeany : MonoBehaviour
{
    int toggle = 0;

    [SerializeField] GameObject pauseMenu;
    public KeyCode PauseHotkey;
    void Update()
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
}
