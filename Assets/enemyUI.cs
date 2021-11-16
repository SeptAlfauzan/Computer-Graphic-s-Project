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
    bool attack = false;

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
        if(attack == false)
        {
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
    }
    public void enemyattack()
    {
        attack = true;
    }
    public void enemynotAttack()
    {
        attack = false;
        animator.ResetTrigger("serang");
    }
    public void enemyDead()
    {
        Destroy(this.gameObject);
    }
}
