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
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("player");
    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }


        //if(Input.GetKeyDown(KeyCode.F)) player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 400f));

        if (getHangOnclif() && Input.GetButtonDown("Jump") && !player.GetComponent<playerpotition>().m_Grounded) { //jumping from clif

                player.GetComponent<HangClif>().unfreezePosition();
                //player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 300f));
                jump = true;
            animator.SetBool("IsJumping", true);
            Debug.Log("test");
        };
    }

    bool getHangOnclif()
    {
        bool res = player.GetComponent<HangClif>().getHangOnClif();
        return res;
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
