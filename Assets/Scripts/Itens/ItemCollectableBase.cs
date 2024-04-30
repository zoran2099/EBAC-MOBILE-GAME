using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string tagPlayer = "Player";
    
    private bool _isCollectable;
    public float timeDestroy = 0.5f;

    public GameObject graphicItem;

    private void Awake()
    {
        _isCollectable = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collect(collision.transform.tag);
    }
    private void OnTriggerEnter(Collider collision)
    {
        Collect(collision.transform.tag);
    }

    private void Collect(String tagCollided)
    {
        if (tagCollided.Equals(tagPlayer) && _isCollectable) {
            
            Debug.Log("Collected");
            _isCollectable = false;
            OnCollect();
        } 
        
        
    }

    private void OnCollect()
    {
        gameObject.SetActive(false);
        
        Destroy(gameObject, timeDestroy);
    }
    
    
}
