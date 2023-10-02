using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonButton : MonoBehaviour
{
    private SpriteRenderer colorSprite;

    public int buttonNumber;

    private SimonSayManager manager;
    
    void Start()
    {
        colorSprite = GetComponent<SpriteRenderer>();
        manager = FindObjectOfType<SimonSayManager>();

    }

    private void Update()
    {
        
    }

    void OnMouseDown()
    {
        colorSprite.color = new Color(colorSprite.color.r, colorSprite.color.g, colorSprite.color.b, 1f);
    }
    
    void OnMouseUp()
    {
        colorSprite.color = new Color(colorSprite.color.r, colorSprite.color.g, colorSprite.color.b, 0.5f);
        manager.ColorPressed(buttonNumber);
    }
}
