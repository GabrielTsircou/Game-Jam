using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcAttackCheck : MonoBehaviour
{
    public float waitTime;
    public float aniTime;
    public bool attackAni;
    public float damage = 5;
    public Vector3 offset;
    public Vector3 offsetInv;
    public GameObject attackPar;
    public GameObject left;
    public GameObject right;
    
    public Animator animator;
    public SpriteRenderer SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 difference = mousePos - transform.position;
            if (difference.x <= 0)
            {
                SpriteRenderer.flipX = true;
                StartCoroutine(attack(left));
                Instantiate(attackPar, transform.position + offset, Quaternion.Euler(0, 270, 0));
            }
            else
            {
                SpriteRenderer.flipX = false;
                StartCoroutine(attack(right));
                Instantiate(attackPar, transform.position + offsetInv, Quaternion.Euler(0, 90, 0));
            }
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawIcon(offset, "offset");
    //}

    private IEnumerator attack(GameObject hitbox)
    {
        yield return new WaitForSeconds(waitTime);
        hitbox.SetActive(true);
        yield return new WaitForSeconds(aniTime);
        hitbox.SetActive(false);
    }
}
