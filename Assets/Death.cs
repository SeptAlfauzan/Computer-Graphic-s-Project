using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    Material materialShader;
    public AudioSource deathaudio;
    bool isDisolve = false;
    float fade = 1f;
    bool isDeath = false;
    // Start is called before the first frame update
    void Start()
    {
        materialShader = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDisolve)
        {
            deathaudio.Play();
            fade -= Time.deltaTime;
            if(fade <= 0)
            {
                fade = 0f;
                isDisolve = false;
                Destroy(this.transform.gameObject);

                isDeath = true;
            }
            materialShader.SetFloat("_Fade", fade);
        }
    }

    void death()
    {
        isDisolve = true;
    }

    public bool getDeathStatus()
    {
        return isDeath;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spikes") death();
        if (collision.tag == "EnemyDepan") death();
        if (collision.tag == "EnemyBelakang") death();
        
    }
}
