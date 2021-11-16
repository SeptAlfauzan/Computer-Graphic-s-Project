using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class depanscript : MonoBehaviour
{
    public SpriteRenderer mySpriteRenderer;
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D Depan) 
    {
        if(Depan.tag == "Player")
        {
            if(mySpriteRenderer.flipX == true)
            {
                mySpriteRenderer.flipX = false;
                animator.SetTrigger("serang");
            }
            else
            {
                animator.SetTrigger("serang");
            }
        }
    }
}
