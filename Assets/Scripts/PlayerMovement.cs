using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    Rigidbody rb;
    Animator animator;

    int isWalkingHash;

    void Start()
    {
        animator= GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        isWalkingHash = Animator.StringToHash("isWalking");
    }

    void FixedUpdate() // FIX!
    {
        bool isWalking  = animator.GetBool(isWalkingHash);

        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(xMove, 0, zMove) * speed + new Vector3(0, rb.velocity.y, 0); // FiX!
    
/*        if() // put in the when moving thing
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }*/
    }
}
