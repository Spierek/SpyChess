using UnityEngine;
using System;
using System.Collections;

public class PieceKnight : Piece {
    #region Monobehaviour
    private void Awake() {

    }
    #endregion

    #region Methods
    protected override bool CheckMovementRule(int newX, int newY) {
        // TODO: implement knight movement
        return false;
    }
    #endregion
}