using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Slider slider;
    public AudioClip clip;
    public AudioSource source;

    private void Update()
    {
        source.volume = slider.value;
    }

   

    public void PlaySound()
    {
        source.PlayOneShot(clip);
    }

}
