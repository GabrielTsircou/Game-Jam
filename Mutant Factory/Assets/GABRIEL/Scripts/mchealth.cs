using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class mchealth : MonoBehaviour
{
    public string deathScene;
    public float mcHealth = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mcHealth <= 0)
        {
            Debug.Log("haha get good bozo");
            SceneManager.LoadScene(deathScene);
        }
    }
}
