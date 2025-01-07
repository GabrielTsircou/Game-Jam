using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class enemyhealth : MonoBehaviour
{
    private float health = 10;
    private float bleedRate = 0;
    private bool isBleeding = false;
    private bool gotGeeked = false;
    public static float damageQueue;
    public float maxHealth = 10;
    public float healRate = 0.5f;
    public float healWaitTime = 3;
    public float damage = 2;
    public bool canDamage = true;
    //public bool canHeal = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (canHeal == true)
        //{
        //    WaitForSeconds(healWaitTime);
        //    health += healRate * Time.deltaTime;
        //}

        if (health == 0)
        {
           gotGeeked = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canDamage == true)
        {
            if (collision.gameObject.TryGetComponent(out mchealth mc))
            {
                mc.mcHealth -= damage;
            }
        }
    }
}

// metro boomin make it boom