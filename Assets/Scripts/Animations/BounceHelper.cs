using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;


public class BounceHelper : MonoBehaviour
{

    [Header("Animation")]
    public float scalaDuration = 0.05f;
    public float scalaBounce = 1.2f;
    public Ease ease = Ease.OutBack;


    // Update is called once per frame
    void Update()
    {
    
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Bounce();
        }

    }

    public void Bounce()
    {
        transform.DOScale(scalaBounce, scalaDuration).SetEase(ease).SetLoops(2, LoopType.Yoyo);

    }
}
