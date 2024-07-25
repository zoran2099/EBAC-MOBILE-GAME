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
    [SerializeField]
    private float waitSpawnScale = 1f;
    [SerializeField]
    private float spawnScaleDuration = 1f;

    private void Start()
    {
        SpawnScale();
    }

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




    IEnumerator ScalePiecesByTime()
    {
        _normalScale = true;
        transform.localScale = Vector3.zero;

        yield return null;

        transform.DOScale(Vector3.one, spawnScaleDuration);
        yield return new WaitForSeconds(waitSpawnScale);
    }

    public void SpawnScale()
    {
        StartCoroutine(ScalePiecesByTime());
        
    }
}
