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
    private bool _normalScale;


    // Update is called once per frame
    void Update()
    {
    
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (_normalScale)
            {
                ScaleUP();
            }
            else
            {
                ScaleDown();
            }
        }

    }

    public void Bounce()
    {
        transform.DOScale(scalaBounce, scalaDuration).SetEase(ease).SetLoops(2, LoopType.Yoyo);

    }

    public void ScaleUP()
    {
        _normalScale = false;
        transform.DOScale(scalaBounce, scalaDuration).SetEase(ease);

    }
    public void ScaleDown()
    {
        _normalScale = true;
        transform.DOScale(1f, scalaDuration).SetEase(ease);

    }
}
