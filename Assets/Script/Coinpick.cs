using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coinpick : MonoBehaviour
{
    private float coin = 0;

    public TextMeshProUGUI Score;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Coin")
        {
            coin++;
            Score.text = coin.ToString();
            Destroy(other.gameObject);
        }
    }
}
