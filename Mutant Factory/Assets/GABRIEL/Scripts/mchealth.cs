using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class mchealth : MonoBehaviour
{
    public Image healthbar;
    public string deathScene;
    public float mcHealth;
    public float maxHealth = 15;
    // Start is called before the first frame update
    void Start()
    {
        mcHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = mcHealth / maxHealth;

        if (mcHealth <= 0)
        {
            Debug.Log("haha get good bozo");
            SceneManager.LoadScene(deathScene);
        }
    }
}
