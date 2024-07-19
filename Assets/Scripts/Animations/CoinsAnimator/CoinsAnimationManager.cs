using DG.Tweening;
using Ebac.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsAnimationManager : Singleton<CoinsAnimationManager>
{


    [Header("Animation")]
    public float scaleDuration = 1.0f;
    public float scaleTimeBetweenPieces = 1.0f;
    public Ease ease = Ease.OutBounce;

    public List<CoinCollectable> coins = new List<CoinCollectable>();

    public void RegisterCoin(CoinCollectable coin)
    {
        if (coins.Contains(coin)) return;

        coin.transform.localScale = Vector3.zero;

        coins.Add(coin); 

    }

    IEnumerator ScalePiecesByTime()
    {
        foreach (var coin in coins)
        {
            coin.transform.localScale = Vector3.zero;
        }

        yield return null;

        for (int i = 0; i < coins.Count; i++)
        {
            coins[i].transform.DOScale(Vector3.one, scaleDuration);
            yield return new WaitForSeconds(scaleTimeBetweenPieces);
        }
    }

    public void StartAnimations()
    {
        StartCoroutine(ScalePiecesByTime());    
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)) {
            StartAnimations();
        }
    }

    private void Start()
    {

    }
}
