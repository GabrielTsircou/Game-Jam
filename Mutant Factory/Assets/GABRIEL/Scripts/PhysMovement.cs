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
    public bool dWalk = false;
    public bool uWalk = false;
    public bool lWalk = false;
    public bool rWalk = false;
    public bool walk = false;

    // bool for toggling inertia
    public bool hasNoMass = false;

    // bool for toggling asset flipping
    public bool flipAsset = true;

    private Rigidbody2D _rb2d;

    public Animator animator;
    public SpriteRenderer SpriteRenderer;

    void Start() //Start is called before the first frame update
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()  // Update is called once per frame
    {
        animator.SetBool("walk", walk);
        //animator.SetBool("walk forward", dWalk);
        //animator.SetBool("walk up", uWalk);
        //animator.SetBool("walk left", lWalk);
        //animator.SetBool("walk right", rWalk);
        
        if (hasNoMass == true) // sets the velocity to zero every frame if true
        {
            _rb2d.velocity = Vector2.zero;
        }

        // toggles each bool and moves character when key pressed, resets when not moving
        if (Input.GetKey(left))
        {
            walk = true;
            lWalk = true;
            rWalk = false;
            uWalk = false;
            dWalk = false;
           _rb2d.velocity = Vector2.left * speed;
            if (flipAsset == true)
            {
                SpriteRenderer.flipX = true;
            }
        }
        else if (Input.GetKey(right))
        {
            walk = true;
            rWalk = true;
            lWalk = false;
            uWalk = false;
            dWalk = false;
            if (flipAsset == true)
            {
                SpriteRenderer.flipX = false;
            }
            _rb2d.velocity = Vector2.right * speed;
        }
        else if (Input.GetKey(up))
        {
            walk = true;
            uWalk = true;
            lWalk = false;
            rWalk = false;
            dWalk = false;
            _rb2d.velocity = Vector2.up * speed;

        }
        else if (Input.GetKey(down))
        {
            walk = true;
            dWalk = true;
            uWalk = false;
            rWalk = false;
            lWalk = false;
            _rb2d.velocity = Vector2.down * speed;
        }
        else
        {
            walk = false;
            dWalk = false;
            uWalk = false;
            rWalk = false;
            lWalk = false;
        }
    }                                         

}

// THIS PROGRAM IS PROPERTY OF
//      __________  ___    __   _______   _____   ___    __  _________
//      //      /   //|    /   //          //     //|    /   //       
//     //======/   // |   /   //_____     //     // |   /   //__      
//    //      /   //  |  /          /    //     //  |  /   //         
//   //      /   //   | /          /    //     //   | /   //          
// _//_    _/_ _//_  _|/_  _______/  __//__  _//_  _|/_ _//______ TM
//
// ANSINE CORP.TM COPYRIGHT 1998 - 2024