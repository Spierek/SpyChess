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
    public PlayerType       currentPlayer;

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
    #endregion
}
