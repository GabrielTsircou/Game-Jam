using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lilguy : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 10;
    public bool hasNoMass = true;
    public float damage = 2;
    public bool canDamage = true;
    // Update is called once per frame
    void Update()
    {
        Vector3 target = playerTransform.position;
        Vector3 calcTarget = Vector3.Lerp(transform.position, target, (moveSpeed + Time.deltaTime)/1000);
        transform.position = calcTarget;
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