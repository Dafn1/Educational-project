using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : Sounds
{
    public GameObject panel;

    void OnTriggerEnter2D(Collider2D myCollider)
    {
        if (myCollider.tag == ("Player"))
        {
            PlaySound(sounds[0]);
            Time.timeScale = 0f;
            panel.SetActive(true);
            
        }
    }



}
