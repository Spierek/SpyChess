using UnityEngine;
using System;
using System.Collections;
using DG.Tweening;

public enum PlayerType {
    White,
    Black
}

public class GameController : MonoBehaviour {
    #region Variables
    public static GameController Instance;

    public BoardGenerator   board;

    [Space(10)]
    public int              turnCounter;
    public PlayerType       currentPlayer;

    public bool             isAnyPieceSelected;
    public Piece            currentPiece;
    #endregion

    #region Monobehaviour
    private void Awake () {
        Instance = this;
        DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
    }
    
    private void Update () {
    
    }
    #endregion

    #region Methods
    public void NextTurn() {
        currentPlayer = currentPlayer == PlayerType.White ? PlayerType.Black : PlayerType.White;
        
        if (currentPlayer == PlayerType.White)
            turnCounter++;
    }

    public void SetCurrentPiece(Piece p) {
        if (isAnyPieceSelected)
            currentPiece.Deselect();

        currentPiece = p;
        isAnyPieceSelected = true;
    }

    public void UnsetCurrentPiece() {
        currentPiece = null;
        isAnyPieceSelected = false;
    }
    #endregion
}
