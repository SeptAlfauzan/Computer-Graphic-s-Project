using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public playerpotition potition;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        potition.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
