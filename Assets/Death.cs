using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    Material materialShader;
    bool isDisolve = false;
    float fade = 1f;
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
            fade -= Time.deltaTime;
            if(fade <= 0)
            {
                fade = 0f;
                isDisolve = false;
                Destroy(this.transform.gameObject);
            }
            materialShader.SetFloat("_Fade", fade);
        }
    }

    void death()
    {
        isDisolve = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spikes") death();
    }
}
