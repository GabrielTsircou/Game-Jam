using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thrower : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 10;
    public bool hasNoMass = true;
    public float damage = 2;
    public bool contactDamage = true;
    public float throwDistance = 10;
    public bool canThrow = true;
    public bool isBomb;
    public bool isBasic;
    public bool isHoming;
    private Vector2 throwStop;
    public float attackCooldown = 50;
    private float cooldown;


    public GameObject bomb;
    public GameObject basic;
    public GameObject homing;

    // Update is called once per frame
    void Update()
    {
        Vector3 target = playerTransform.position;
        Vector3 calcTarget = Vector3.Lerp(transform.position, target, (moveSpeed + Time.deltaTime) / 1000);
        transform.position = calcTarget;

        if (Vector2.Distance(transform.position, playerTransform.position) <= throwDistance && cooldown <= 0)
        {
            if (isBomb == true)
            {
                GameObject newbomb = Instantiate(bomb, transform.position, Quaternion.identity);
                newbomb.GetComponent<Rigidbody2D>().velocity = new Vector2 (x: 5, y: 5);
            }
            else if (isBasic == true)
            {
                Instantiate(basic, transform.position, Quaternion.identity);
            }
            else if (isHoming == true)
            {
                Instantiate(homing, transform.position, Quaternion.identity);
            }
            cooldown = attackCooldown;
        }
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        //playerTransform.GetComponent<CircleCollider2D>
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, throwDistance);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (contactDamage == true)
        {
            if (collision.gameObject.TryGetComponent(out mchealth mc))
            {
                mc.mcHealth -= damage;
            }
        }
    }
}