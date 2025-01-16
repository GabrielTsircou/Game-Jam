using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public KeyCode next = KeyCode.LeftArrow, back= KeyCode.RightArrow;
    public string nextScene;
    public string lastScene;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(next))
        {
            SceneManager.LoadScene(nextScene);
        }
           
        if (Input.GetKey(back))
        {
            SceneManager.LoadScene(lastScene);
        }

    }
}
