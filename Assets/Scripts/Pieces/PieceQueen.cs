using UnityEngine;
using System;
using System.Collections;

public class PieceQueen : Piece {
    #region Monobehaviour
    private void Awake() {

    }
    #endregion

    #region Methods
    protected override bool CheckMovementRule(int newX, int newY) {
        // TODO: implement queen movement
        return false;
    }
    #endregion
}

