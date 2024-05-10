using DG.Tweening;
using Ebac.Core.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    
    [Header("Lerp")]
    public float lerpSpeed = 0.5f;
    public Transform target;
    private Vector3 _position;


    [Header("Player Settings")]
    public float speed = 1f;
    private bool _isLive = false;
    private Vector3 _startPosition;
    public string enemyTag = "Enemy";
    public string endTag = "End";

    [Header("UI")]
    public LoadSceneHelper LoadSceneHelper;
    public float TimeToLoadScene = 1.5f;

    [Header("Power Ups")]
    public TextMeshPro textPowerUp;
    private float _currentSpeed;
    private bool _isInvencible;

    [Header("Coin Setup")]
    public GameObject coinCollector;


    [Header("Animation")]
    public AnimatorManager animatorManager;
    public float EndValueImpactCollision = 1f;
    public float Duration = .3f;
    private float _baseSpeedAnniation = 7f;
    
    
    
    #region Unity

    private void Start()
    {
        ResetGame();


    }

    
        
    // Update is called once per frame
    void Update()
    {
        if (!_isLive) return;

        _position = target.position;
        _position.y = transform.position.y;
        _position.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _position, lerpSpeed * Time.deltaTime);

        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(enemyTag) && !_isInvencible) {
            ImpactMove(collision.transform); 
            EndGame(); 
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(endTag)) EndGame(); 
    }
    #endregion


    #region Scene Logic

    private void ImpactMove(Transform transform)
    {
        transform.DOMoveZ(EndValueImpactCollision, Duration).SetRelative();
    }

    
    private void ResetGame()
    {
        _startPosition = new Vector3(0f, -0.27f, 0f);//transform.position;

        _currentSpeed = speed;
        PlayIdleAnimation();

    }

    private void EndGame()
    {
        _isLive = false;
        PlayDeathAnimation();

        if (LoadSceneHelper != null) Invoke(nameof(LoadScene), TimeToLoadScene);


    }
   


    private void LoadScene()
    {
        LoadSceneHelper.Load(0);
    }

    public void StartGame()
    {
        _isLive = true;
        transform.position = _startPosition;
        PlayRunAnimation();

    }
    #endregion

    #region Power UPs

    public void ResetSpeed()
    {
        _currentSpeed = speed;
        PlayRunAnimation();
    }

    
    public void PowerUPSpeed(float amountToSpeed)
    {
        _currentSpeed = amountToSpeed;

        PlayRunAnimation();
    }

    public void SetInvencible(bool value) { 
        _isInvencible = value; 
    }

    public void SetTextPowerUP(String text)
    {
        textPowerUp.text = text;
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        transform.DOMoveY(_startPosition.y + amount,animationDuration).SetEase(ease);//.OnComplete(ResetHeight);        
        Invoke(nameof(ResetHeight), duration);
    }

    public void ResetHeight(float animationDuration)
    {
        transform.DOMoveY(_startPosition.y, animationDuration);
    }

    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }




    #endregion


    #region Animattion

    private void PlayIdleAnimation()
    {
        animatorManager.PlayAnimation(AnimatorManager.AnimationType.IDLE);
    }

    private void PlayRunAnimation()
    {
        animatorManager.PlayAnimation(AnimatorManager.AnimationType.RUN, _currentSpeed / _baseSpeedAnniation);
    }

    private void PlayDeathAnimation()
    {
        animatorManager.PlayAnimation(AnimatorManager.AnimationType.DEAD);
    }
    #endregion
}
