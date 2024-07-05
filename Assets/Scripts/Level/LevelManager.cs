using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;

    public List<GameObject> level;

    [Header("Pieces")]
    public List<LevelPieceBase> levelPieces;
    public LevelPieceBase initPiece;
    public LevelPieceBase finalPiece;

    //TODO Create an object to keep a reference to the randomized level so that every time a new level is created, the old one is destroyed, thus avoiding duplicates.
    private List<LevelPieceBase> _spawnedLevelPieces;
    public int piecesNumber = 10; 



    [SerializeField]
    private int _indexLevel;

    private GameObject _currentLevel;


    // Start is called before the first frame update
    /*
    void Start()
    {


        _currentLevel = SpawnLevel(level[_indexLevel], container);
    }
    */
    private void Awake()
    {
        //SpawnNextLevel();
        //CreateLevelFromPieces();
        StartCoroutine(CreateLevelFromPiecesCoroutine());
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
        // This block of code is solely for testing purposes during the development phase
        // This code will not work for Random Level.
        if (Input.GetKeyDown(KeyCode.D))
        {
            SpawnNextLevel();

        }
    }

    private void CreateLevelFromPieces()
    {
        _spawnedLevelPieces = new List<LevelPieceBase>();

        CreateInitPiece();
        
        for (int i = 0; i < piecesNumber; i++)
        {
            CreateLevelPiece();
        }

        CreateFinalPiece();
    }

    private IEnumerator CreateLevelFromPiecesCoroutine()
    {
        _spawnedLevelPieces = new List<LevelPieceBase>();

        CreateInitPiece();
        yield return new WaitForSeconds(.3f);

        for (int i = 0; i < piecesNumber; i++)
        {
            CreateLevelPiece();
            yield return new WaitForSeconds(.3f);
        }
        
        CreateFinalPiece();
        yield return new WaitForSeconds(.3f);
    }

    private void CreateFinalPiece()
    {
        var spawnedPiece = Instantiate(finalPiece, container);

        var lastPiece = _spawnedLevelPieces[_spawnedLevelPieces.Count - 1];
        spawnedPiece.transform.position = lastPiece.endPiece.position;

        _spawnedLevelPieces.Add(spawnedPiece);

    }

    private void CreateInitPiece()
    {
        var spawnedPiece = Instantiate(initPiece, container);
        _spawnedLevelPieces.Add(spawnedPiece);
    }

    private void CreateLevelPiece()
    {
        var piece = levelPieces[Random.Range(0, levelPieces.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if (_spawnedLevelPieces.Count > 0)
        {
            var lastPiece = _spawnedLevelPieces[_spawnedLevelPieces.Count - 1];
            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }

        _spawnedLevelPieces.Add(spawnedPiece);

    }
}
