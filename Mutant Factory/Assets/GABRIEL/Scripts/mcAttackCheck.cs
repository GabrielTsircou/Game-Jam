using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcAttackCheck : MonoBehaviour
{
    public float aniTime;
    public float damage = 5;
    public GameObject left;
    public GameObject right;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 difference = mousePos - transform.position;
            if (difference.x <= 0)
            {
                StartCoroutine(attack(left));
            }
            else
            {
                StartCoroutine(attack(right));
            }
        }
    }
   
    private IEnumerator attack(GameObject hitbox)
    {
        hitbox.SetActive(true);
        yield return new WaitForSeconds(aniTime);
        hitbox.SetActive(false);
    }
}
