using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Lerp")]
    public float lerpSpeed = 0.5f;
    public Transform target;
    private Vector3 _position;


    [Header("Player Settings")]
    public float speed = 1f;
    private bool _isLive = true;
    public string enemyTag = "Enemy";

    // Update is called once per frame
    void Update()
    {
        if (!_isLive) return;

        _position = target.position;
        _position.y = transform.position.y;
        _position.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _position, lerpSpeed * Time.deltaTime);

        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(enemyTag)) _isLive = false;
    }

}
