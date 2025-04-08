using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TipsTrigger : Sounds
{
    [Header("Teat messange")]
    [TextArea(3, 10)]
    [SerializeField] private string message;

    
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlaySound(sounds[0]);
            TipsManager.displayTipsElement?.Invoke(message);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TipsManager.disableTipsElement?.Invoke();
        }
    }
}
