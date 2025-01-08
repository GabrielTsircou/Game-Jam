using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoman : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 10;
    public bool hasNoMass = true;
    public float damage = 2;
    public bool canAttack = true;
    public float throwDistance = 10;
    public bool canThrow = true;
    private Vector2 throwStop;
    public float attackCooldown = 50;
    private float cooldown;


    public GameObject bomb;

    // Update is called once per frame
    void Update()
    {
        Vector3 target = playerTransform.position;
        Vector3 calcTarget = Vector3.Lerp(transform.position, target, (moveSpeed + Time.deltaTime) / 1000);
        transform.position = calcTarget;


        if (Vector2.Distance(transform.position, playerTransform.position) <= throwDistance && cooldown <= 0) 
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
            cooldown = attackCooldown;
        }
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, throwDistance);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canAttack == true)
        {
            if (collision.gameObject.TryGetComponent(out mchealth mc))
            {
                mc.mcHealth -= damage;
            }
        }
    }
}