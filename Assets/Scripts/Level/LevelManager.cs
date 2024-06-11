using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LevelManager : MonoBehaviour
{
    public Transform container;

    public List<GameObject> level;

    [SerializeField]
    private int _indexLevel;

    private GameObject _currentLevel;
    

    // Start is called before the first frame update
    void Start()
    {


        _currentLevel = SpawnLevel(level[_indexLevel], container);
    }

    
    private void SpawnNextLevel()
    {
        if (_currentLevel != null)
        {
            Destroy(_currentLevel);
            _indexLevel++;
        }
        
        if(_indexLevel >= level.Count) _indexLevel = 0;


         _currentLevel = SpawnLevel(level[_indexLevel], container);

    }

    private GameObject SpawnLevel(GameObject level, Transform container)
    {
        var currentLevel =  Instantiate(level, container);

        return currentLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            SpawnNextLevel();
        }
    }
}
