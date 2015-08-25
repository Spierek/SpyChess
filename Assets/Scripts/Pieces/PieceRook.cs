using UnityEngine;
using System;
using System.Collections;

public class PieceRook : Piece {
    #region Monobehaviour
    private void Awake() {

    }
    #endregion

    #region Methods
    protected override bool CheckMovementRule(int newX, int newY) {
        // TODO: implement rook movement
        return false;
    }
    #endregion
}