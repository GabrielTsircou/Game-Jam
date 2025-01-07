using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class healthsys : MonoBehaviour
{
    private float health = 10;
    private float bleedRate = 0;
    private bool isBleeding = false;
    private bool gotGeeked = false;
    public float maxHealth = 10;
    public float healRate = 0.5f;
    public float healWaitTime = 3;
    public float damage = 2;
    public bool canDamage = true;
    //public bool canHeal = false;
    public bool isMC = false;
    public string deathScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canDamage == true)
        {

        }

        //if (canHeal == true)
        //{
        //    WaitForSeconds(healWaitTime);
        //    health += healRate * Time.deltaTime;
        //}

        if (health == 0)
        {
            if (isMC == true)
            {
                SceneManager.LoadScene(deathScene);
            }
            else
            {
                gotGeeked = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}

// metro boomin make it boom