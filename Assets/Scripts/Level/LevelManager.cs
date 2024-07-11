using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;

    public List<GameObject> level;

    
    public List<LevelPieceBaseSetup> levelPieceBaseSetup;
    private LevelPieceBaseSetup _currentLevelPieceBaseSetup;
    
    //TODO Create an object to keep a reference to the randomized level so that every time a new level is created, the old one is destroyed, thus avoiding duplicates.
    private List<LevelPieceBase> _spawnedLevelPieces = new List<LevelPieceBase>();

    [SerializeField]
    private int _indexLevel = 0;
    private int _indexLevelSetup = 0;

    private GameObject _currentLevel;

    #region Unty
    

    // Start is called before the first frame update
    /*
    void Start()
    {


        _currentLevel = SpawnLevel(level[_indexLevel], container);
    }
    */
    private void Awake()
    {
        NextLevelPieceSetup();
        //SpawnNextLevel();
        //CreateLevelFromPieces();
        StartCoroutine(CreateLevelFromPiecesCoroutine());
    }


    // Update is called once per frame
    void Update()
    {
        // This block of code is solely for testing purposes during the development phase
        // This code will not work for Random Level.
        if (Input.GetKeyDown(KeyCode.D))
        {
            //SpawnNextLevel();
            NextLevelPieceSetup();
            //CreateLevelFromPieces();
            StartCoroutine(CreateLevelFromPiecesCoroutine());

        }
    }



    #endregion






    private void NextLevelPieceSetup()
    {
        _indexLevelSetup++;
        
        if(_indexLevelSetup >= levelPieceBaseSetup.Count) _indexLevelSetup = 0;
        
        _currentLevelPieceBaseSetup = levelPieceBaseSetup[_indexLevelSetup];
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


    private void CreateLevelFromPieces()
    {
        ClearSpawnedPieces();

        CreateInitPiece();

        for (int i = 0; i < _currentLevelPieceBaseSetup.piecesNumber; i++)
        {
            CreateNexLevelPiece();
        }

        CreateFinalPiece();
    }

    private void ClearSpawnedPieces()
    {
        // TODO try use while
        for (int i = _spawnedLevelPieces.Count - 1 ; i >= 0; i--)
        {
            Destroy(_spawnedLevelPieces[i].gameObject);
        }

        _spawnedLevelPieces.Clear();
    }

    private IEnumerator CreateLevelFromPiecesCoroutine()
    {
        ClearSpawnedPieces();

        CreateInitPiece();
        yield return new WaitForSeconds(.3f);

        for (int i = 0; i < _currentLevelPieceBaseSetup.piecesNumber; i++)
        {
            CreateNexLevelPiece();
            yield return new WaitForSeconds(.3f);
        }
        
        CreateFinalPiece();
        yield return new WaitForSeconds(.3f);
    }

    private void CreateFinalPiece()
    {
        var spawnedPiece = Instantiate(_currentLevelPieceBaseSetup.finalPiece, container);

        var lastPiece = _spawnedLevelPieces[_spawnedLevelPieces.Count - 1];
        spawnedPiece.transform.position = lastPiece.endPiece.position;

        _spawnedLevelPieces.Add(spawnedPiece);

    }

    private void CreateInitPiece()
    {
        var spawnedPiece = Instantiate(_currentLevelPieceBaseSetup.initPiece, container);
        _spawnedLevelPieces.Add(spawnedPiece);
    }

    private void CreateNexLevelPiece()
    {
        var piece = _currentLevelPieceBaseSetup.levelPieces[Random.Range(0, _currentLevelPieceBaseSetup.levelPieces.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if (_spawnedLevelPieces.Count > 0)
        {
            var lastPiece = _spawnedLevelPieces[_spawnedLevelPieces.Count - 1];
            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }

        _spawnedLevelPieces.Add(spawnedPiece);

    }
}