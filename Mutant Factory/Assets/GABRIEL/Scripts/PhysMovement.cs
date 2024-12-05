using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PhysMovement : MonoBehaviour
{
    //keycodes!!!!!!!!!!!!!!!!
    public KeyCode left = KeyCode.A, right = KeyCode.D, up = KeyCode.W, down = KeyCode.S;
    // sets move speed
    public float speed = 10;
    // vectors for animators
    public bool fWalk = false;
    public bool uWalk = false;
    public bool lWalk = false;
    public bool rWalk = false;
    // bool for toggling inertia
    public bool hasNoMass = false;
    //public Animator animator;
    private Rigidbody2D _rb2d;

    public SpriteRenderer SpriteRenderer;
    public float input;

    void Start() //Start is called before the first frame update
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()  // Update is called once per frame
    {
        //animator.SetBool("walk forward", fWalk);
        //animator.SetBool("walk up", uWalk);
        //animator.SetBool("walk left", lWalk);
        //animator.SetBool("walk right", rWalk);

        // sets the velocity to zero every frame if true
        if (hasNoMass == true)
        {
           _rb2d.velocity = Vector2.zero;
        }
        
        if (Input.GetKey(left))
        {
           _rb2d.velocity = Vector2.left * speed;
           lWalk = true;
           SpriteRenderer.flipX = true;

        }
        else
        {
            lWalk = false;
        }

        if (Input.GetKey(right))
        {
            _rb2d.velocity = Vector2.right * speed;
           rWalk = true;
           SpriteRenderer.flipX = false;
        }
        else
        {
            rWalk = false;
        }

        if (Input.GetKey(up))
        {
            _rb2d.velocity = Vector2.up * speed;
            uWalk = true;
        }
        else
        {
            uWalk = false;
        }

        if (Input.GetKey(down))
        {
            _rb2d.velocity = Vector2.down * speed;
            fWalk = true;
        }
        else
        {
            fWalk = false;
        }
    }
}
