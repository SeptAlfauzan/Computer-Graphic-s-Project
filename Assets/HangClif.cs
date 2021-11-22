using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangClif : MonoBehaviour
{
    // Start is called before the first frame update
    public float duration = 1.5f;
    public Collider2D HangArea;
    public Rigidbody2D rigid;
    bool collideWithClif = false;
    bool hangOnClif = false;
    bool hangTimeOver = false;

    float hangTimeStart = 0;
    float hangTimeElapse = 0; 
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tilemap" && collision.collider == HangArea) Debug.Log("collide");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tilemap") collideWithClif = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tilemap") collideWithClif = false;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(CalculateHangTime());
        if (CalculateHangTime() > duration)
        {
            hangTimeOver = true;
            
            Debug.Log("subur waktumu sudah habis");
        }

        if (Input.GetKeyDown(KeyCode.RightControl) && collideWithClif)
        {
            hangTimeStart = Time.time;
            freezeYposition();
        }

        if (Input.GetKeyUp(KeyCode.RightControl) || CalculateHangTime() > duration) unfreezePosition();




    }

    float CalculateHangTime()
    {
        if (hangOnClif)
        {
            hangTimeElapse = Time.time - hangTimeStart;
        }
        else
        {
            hangTimeElapse = 0;
        }
        return hangTimeElapse;
    }

    public void freezeYposition()
    {
        rigid.constraints = RigidbodyConstraints2D.FreezePosition;
        hangOnClif = true;
    }

    public void unfreezePosition()
    {
        rigid.constraints = RigidbodyConstraints2D.None;
        rigid.angularVelocity = 0;
        transform.rotation = Quaternion.identity;
        rigid.MoveRotation(0);//reset rotation of rigid boy
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
        hangOnClif = false;
    }

    public bool getHangOnClif()
    {
        return hangOnClif;
    }
}
