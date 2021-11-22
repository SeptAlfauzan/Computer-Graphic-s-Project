using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class belakangscript : MonoBehaviour
{
    public SpriteRenderer mySpriteRenderer;
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D Belakang)
    {
        if(Belakang.tag == "Player")
        {
            
            if(mySpriteRenderer.flipX == false)
            {
                mySpriteRenderer.flipX = true;
                animator.SetBool("serang 0",true);
            }
            else if(mySpriteRenderer.flipX == true)
            {
                animator.SetBool("serang 0",true);
            }
            else
            {
                animator.SetBool("serang 0",false);
            }
        }
    }
}
