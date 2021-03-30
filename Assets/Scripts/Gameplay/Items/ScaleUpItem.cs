﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUpItem : HeldItem
{
    // the base speed and the speed multiplayer
    private Vector3 baseScale;
    private Vector3 newScale = new Vector3(4.0F, 4.0F, 4.0F);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // apply the effect to the game object
    protected override void ApplyEffect()
    {
        baseScale = activator.transform.localScale;
        activator.transform.localScale = newScale;
    }

    // apply the effect to the player
    protected override void RemoveEffect()
    {
        // restores base speed.
        activator.transform.localScale = baseScale;
    }

    // Update is called once per frame
    // void Update()
    // {
    // }
}