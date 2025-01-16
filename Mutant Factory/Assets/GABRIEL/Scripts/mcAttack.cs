using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcAttack : MonoBehaviour
{
    public mcAttackCheck mcAttackCheck;
    //public float aDamage = mcAttackCheck.damage;
    //private float aDamage = mcAttackCheck.damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //THIS TRIGGERS THE THROW THROUGH THE COLLIDER2D AAAAAAAAAAAAAAAAAAAAAAAAAAA
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out basichealth enemy))
        {
            enemy.health =  enemy.health - mcAttackCheck.damage;
            Debug.Log("smthn idk");

            collision.gameObject.GetComponent<Animator>().SetTrigger("hurt");
        }
    }
}
