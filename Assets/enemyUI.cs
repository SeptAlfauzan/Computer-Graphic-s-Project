using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyUI : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    public float movingSpeed;
    public float minDist;
    public float maxDist;
    private Vector3 initialPosition;
    public Animator animator;
    int direction;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        initialPosition = transform.position;
        direction = -1;
        maxDist += transform.position.x;
        minDist -= transform.position.x;
    }

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(movingSpeed));
        switch (direction)
        {
            case -1:
                if(transform.position.x > minDist)
                {
                    GetComponent<Rigidbody2D>().velocity= new Vector2(-movingSpeed,GetComponent<Rigidbody2D>().velocity.y);
                }
                else
                {
                    mySpriteRenderer.flipX = true;
                    direction = 1;
                }
                break;
            case 1:
                if(transform.position.x < maxDist)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(movingSpeed,GetComponent<Rigidbody2D>().velocity.y);
                }
                else
                {
                    mySpriteRenderer.flipX = false;
                    direction = -1;
                }
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            animator.SetTrigger("die");
        }
    }
    public void enemyDead()
    {
        Destroy(this.gameObject);
    }
}
