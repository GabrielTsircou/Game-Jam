using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thrower : MonoBehaviour
{
    private Transform playerTransform;
    public float maxSpeed = 10;
    public float moveSpeed;
    public bool isWalk = true;
    public bool hasNoMass = true;
    public float damage = 2;
    public bool contactDamage = true;
    public float throwDistance = 10;
    public bool canThrow = true;
    private bool isLeft;
    public bool isBomb;
    public bool isBasic;
    public bool isHoming;
    public bool throwAni = false;
    public float aniTime;
    private Vector2 throwStop;
    public Vector2 throwArc;
    public float attackCooldown = 3;
    private float cooldown;

    public Animator animator;
    public CircleCollider2D CircleCollider2D;
    public SpriteRenderer spriteRenderer;

    public GameObject bomb;
    public GameObject basic;
    public GameObject homing;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        animator.SetBool("throw ani", throwAni);
        animator.SetBool("walk", isWalk);

        Vector3 target = playerTransform.position;
        Vector3 calcTarget = Vector3.Lerp(transform.position, target, (moveSpeed + Time.deltaTime) / 1000);
        transform.position = calcTarget;
        if (transform.position.x > playerTransform.position.x)
        {
            spriteRenderer.flipX = false;
            isLeft = true;
        }
        else
        {
            spriteRenderer.flipX = true;
            isLeft = false;
        }

        if (Vector2.Distance(transform.position, playerTransform.position) <= throwDistance && cooldown <= 0)
        {
            //StartCoroutine(throwerAni());
        }

        //CircleCollider2D.radius = throwDistance;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StopAllCoroutines();
        StartCoroutine(throwerAni());
    }
    private IEnumerator throwerAni()
    {
        moveSpeed = 0;
        isWalk = false;
        throwAni = true;
        yield return new WaitForSeconds(aniTime);
        if (isBomb == true)
        {
            GameObject newbomb = Instantiate(bomb, transform.position, Quaternion.identity);
            newbomb.GetComponent<bomb>().thrower = this;
            if (isLeft == true)
                newbomb.GetComponent<Rigidbody2D>().velocity = new Vector2(x: throwArc.x * -1, y: throwArc.y);
            else
            {
                newbomb.GetComponent<Rigidbody2D>().velocity = new Vector2(x: throwArc.x, y: throwArc.y);
            }
        }
        else if (isBasic == true)
        {
            Instantiate(basic, transform.position, Quaternion.identity);
        }
        else if (isHoming == true)
        {
            Instantiate(homing, transform.position, Quaternion.identity);
        }

        yield return new WaitForSeconds(aniTime);
        moveSpeed = maxSpeed;
        throwAni = false;
        isWalk = true;
        yield return new WaitForSeconds(attackCooldown);
    }
}