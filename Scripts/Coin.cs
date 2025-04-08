using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource coinAudio;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Player"))
        {
            coinAudio.Play();
            CoinText.coin += 1;
            Destroy(gameObject);

        }


    }
   
}
