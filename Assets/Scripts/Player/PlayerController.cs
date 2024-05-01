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

    [Header("Power Ups")]
    private float _currentSpeed;

    private void Start()
    {
        _startPosition = new Vector3(0f, -0.27f, 0f);//transform.position;

        ResetSpeed();
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
        if (collision.transform.CompareTag(enemyTag)) EndGame();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(endTag)) EndGame();
    }

    private void EndGame()
    {
        _isLive = false;

        if (LoadSceneHelper != null) Invoke(nameof(LoadScene), 1.5f);


    }

    private void LoadScene()
    {
        LoadSceneHelper.Load(0);
    }

    public void StartGame()
    {
        _isLive = true;
        transform.position = _startPosition;

    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void PowerUPSpeed(float amountToSpeed)
    {
        _currentSpeed = amountToSpeed;
    }

    


}
