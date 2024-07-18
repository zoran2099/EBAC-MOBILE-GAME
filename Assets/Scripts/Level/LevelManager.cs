using DG.Tweening;
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



    [Header("Animation")]
    public float scaleDuration = 1.0f;
    public float scaleTimeBetweenPieces = 1.0f;
    public Ease ease = Ease.OutBounce;


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
        CreateLevelFromPieces();
        //StartCoroutine(CreateLevelFromPiecesCoroutine());
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
            CreateLevelFromPieces();
            //StartCoroutine(CreateLevelFromPiecesCoroutine());

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

        ColorManager.Instance.ChangeColorByType(_currentLevelPieceBaseSetup.artType);
        StartCoroutine(ScalePiecesByTime());
    }

    private void CreateLevelFromPiecesOld()
    {
        ClearSpawnedPieces();

        CreateInitPiece();

        for (int i = 0; i < _currentLevelPieceBaseSetup.piecesNumber; i++)
        {
            CreateNexLevelPiece();
        }

        CreateFinalPiece();

        ColorManager.Instance.ChangeColorByType(_currentLevelPieceBaseSetup.artType);
                
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
        var spawnedPiece = GetSpawnedPiece(_currentLevelPieceBaseSetup.finalPiece);

        var lastPiece = _spawnedLevelPieces[_spawnedLevelPieces.Count - 1];
        spawnedPiece.transform.position = lastPiece.endPiece.position;

        _spawnedLevelPieces.Add(spawnedPiece);

    }

    private void CreateInitPiece()
    {
        var spawnedPiece = GetSpawnedPiece(_currentLevelPieceBaseSetup.initPiece);

        _spawnedLevelPieces.Add(spawnedPiece);
    }

    private LevelPieceBase GetSpawnedPiece(LevelPieceBase piece)
    {
        var spawnedPiece = Instantiate(piece, container);

        foreach (var itemArtPiece in spawnedPiece.GetComponentsInChildren<ArtPiece>())
        {
            itemArtPiece.ChangePiece(ArtManager.Instance.GetSetupByType(_currentLevelPieceBaseSetup.artType).gameObject);
        }
        return spawnedPiece;
    }

    private void CreateNexLevelPiece()
    {
        var piece = _currentLevelPieceBaseSetup.levelPieces[Random.Range(0, _currentLevelPieceBaseSetup.levelPieces.Count)];
        var spawnedPiece = GetSpawnedPiece(piece);

        if (_spawnedLevelPieces.Count > 0)
        {
            var lastPiece = _spawnedLevelPieces[_spawnedLevelPieces.Count - 1];
            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }

        _spawnedLevelPieces.Add(spawnedPiece);

    }

    IEnumerator ScalePiecesByTime()
    {
        foreach (var piece in _spawnedLevelPieces)
        {
            piece.transform.localScale = Vector3.zero;
        }

        yield return null;

        for (int i = 0; i < _spawnedLevelPieces.Count; i++)
        {
            _spawnedLevelPieces[i].transform.DOScale(1, scaleDuration);
            yield return new WaitForSeconds(scaleTimeBetweenPieces);
        }
    }


   
}
