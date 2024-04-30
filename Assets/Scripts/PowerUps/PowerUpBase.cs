using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PowerUpBase : ItemCollectableBase {
    
    [Header("Power UP Settings")]
    public float effectDuration;

    protected override void Awake()
    {
        base.Awake();
        Assert.IsTrue(effectDuration < timeDestroy, "Assertion failed: Time to destroy must be greater than effect duration.");

    }

    protected override void OnCollect()
    {
        base.OnCollect();
        StartPowerUp();
    }

    protected virtual void StartPowerUp()
    {
        Debug.Log("Started Power Up");
        
        Invoke(nameof(EndPowerUp), effectDuration);
    }

    protected virtual void EndPowerUp()
    {
        Debug.Log("End Power Up");        
    }
}
