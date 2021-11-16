using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headscript : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D Head) 
    {
        if(Head.tag == "Player")
        {
            animator.SetTrigger("die");
        }
    }
}
