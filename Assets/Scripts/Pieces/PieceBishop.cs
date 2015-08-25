using UnityEngine;
using System;
using System.Collections;

public class PieceBishop : Piece {
    #region Monobehaviour
    private void Awake() {

    }
    #endregion

    #region Methods
    protected override bool CheckMovementRule(int newX, int newY) {
        // TODO: implement bishop movement
        return false;
    }
    #endregion
}