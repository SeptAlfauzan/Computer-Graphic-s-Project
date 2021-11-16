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
                animator.SetTrigger("serang");
            }
            else
            {
                animator.SetTrigger("serang");
            }
        }
    }
}
