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

    protected virtual void Awake()
    {
        _isCollectable = true;
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        Collect(collision.transform.tag);
    }

    protected virtual void Collect(String tagCollided)
    {
        if (tagCollided.Equals(tagPlayer) && _isCollectable) {
            
            Debug.Log("Collected");
            _isCollectable = false;
            OnCollect();
        } 
        
        
    }

    protected virtual void OnCollect()
    {
        gameObject.SetActive(false);
        
        Destroy(gameObject, timeDestroy);
    }
    
    
}
