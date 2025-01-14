using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public thrower thrower;
    public GameObject explosion;
    public float blastRadius = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, blastRadius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out mchealth mc))
        {
            mc.mcHealth -= thrower.damage;
        }
        Instantiate (explosion, transform.position, Quaternion.Euler(90,0,0));
        Destroy(gameObject);
    }
}
