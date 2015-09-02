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
    public UIManager        uiManager;

    [Space(10)]
    public int              turnCounter;
    public PlayerType       currentPlayer;

    public bool             isAnyPieceSelected;
    public Piece            currentPiece;
    #endregion

    #region Delegates
    public delegate void OnNextTurnDelegate(int turns, PlayerType type);
    public static event OnNextTurnDelegate OnNextTurn;
    #endregion

    #region Monobehaviour
    private void Awake () {
        Instance = this;
        DOTween.Init(false, true, LogBehaviour.ErrorsOnly);

        turnCounter = 1;
    }
    #endregion

    #region Methods
    public void NextTurn() {
        currentPlayer = currentPlayer == PlayerType.White ? PlayerType.Black : PlayerType.White;
        
        if (currentPlayer == PlayerType.White)
            turnCounter++;

        if (OnNextTurn != null)
            OnNextTurn(turnCounter, currentPlayer);
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

    public void SetCurrentPieceType(PieceType type) {
        if (isAnyPieceSelected && currentPiece.type == PieceType.Spy) {
            
        }
    }
    #endregion
}
