using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthsys : MonoBehaviour
{
    public float health = 10;
    public double healRate = 0.5;
    public float healWaitTime = 3;
    public float damage = 2;
    public bool canDamage = true;
    public bool canHeal = false;
    public bool isMC = false;
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

        if (canHeal == true)
        {

        }
        if (health == 0)
        {
            if (isMC == true)
            {

            }
            else
            {

            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
