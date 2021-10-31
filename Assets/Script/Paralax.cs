using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    float length, startPosX, startPosY;
    public Camera camra;
    public float paralaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (camra.transform.position.x * (1 - (paralaxEffect)));
        float distX = (camra.transform.position.x * paralaxEffect);
        float distY = (camra.transform.position.y * paralaxEffect);
        transform.position = new Vector3(startPosX + distX, startPosY + distY, transform.position.z);

        if (temp > startPosX + length) startPosX += length;
        else if (temp < startPosX - length) startPosX -= length;
    }
}
