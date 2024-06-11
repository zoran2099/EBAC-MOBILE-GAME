using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;

    public GameObject level;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnLevel(level, container);
    }

    private void SpawnLevel(GameObject level, Transform container)
    {
        var currentLevel =  Instantiate(level, container);

        if (currentLevel != null)
        {
            currentLevel.transform.localPosition = Vector3.zero;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
