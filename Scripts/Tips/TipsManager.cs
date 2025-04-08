using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TipsManager : MonoBehaviour
{
    public static Action<string> displayTipsElement;
    public static Action disableTipsElement;


    [SerializeField] private TMP_Text messageText;

    private Animator anim;

    private int activeTips;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        displayTipsElement += DisplayTip;
        disableTipsElement += DisableTip;
    }
    private void OnDisable()
    {
        displayTipsElement -= DisplayTip;
        disableTipsElement -= DisableTip;
    }
    private void DisplayTip(string massage)
    {
        messageText.text = massage;
        anim.SetInteger("state", ++activeTips);
    }

    private void DisableTip()
    {
        anim.SetInteger("state", --activeTips);
    }
}
