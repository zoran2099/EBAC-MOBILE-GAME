using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelPieceBaseSetup : ScriptableObject
{
    [Header("Art")]
    public ArtManager.ArtType artType;

    [Header("Pieces")]
    public List<LevelPieceBase> levelPieces;
    public LevelPieceBase initPiece;
    public LevelPieceBase finalPiece;
    public int piecesNumber = 10;

}
