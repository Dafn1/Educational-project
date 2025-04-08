using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    public TextMeshProUGUI text;
    private Player player;
    public static int coin;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        
        text.text = coin.ToString();
    }
}
