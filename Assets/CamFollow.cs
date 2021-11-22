using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public BoxCollider2D mapBounds;
    private float xMin, xMax, yMin, yMax;
    private float camY, camX;
    private float camOrthsize;
    private float cameraRatio;
    private Camera mainCam;

    private void Start()
    {
        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;
        mainCam = this.GetComponent<Camera>();
        camOrthsize = mainCam.orthographicSize;
        cameraRatio = (xMax + camOrthsize) / 2.0f;
        Debug.Log("boundary max X "+xMax);
        Debug.Log("boundary min X " + xMin);
    }
    private void FixedUpdate()
    {
        MoveCam();
    }

    void MoveCam()
    {
        if (player)
        {
            camY = Mathf.Clamp(player.position.y, yMin + camOrthsize, yMax - camOrthsize);
            camX = Mathf.Clamp(player.position.x, xMin + cameraRatio, xMax - cameraRatio);
            this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        }
    }
}
