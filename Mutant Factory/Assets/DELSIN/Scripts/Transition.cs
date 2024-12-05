using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Transition : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public string j;

    public static float CD;
    private static float cCD;
    private void Update()
    {
        if (cCD > 0)
        {
            cCD -= Time.deltaTime;
        }
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (cCD <= 0)
        {
            cCD = 1;
            Debug.Log("Testing testing");
            SceneManager.LoadScene(j);
        }
        
    }
}
