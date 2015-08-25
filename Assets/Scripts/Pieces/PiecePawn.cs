using UnityEngine;
using System;
using System.Collections;

public class PiecePawn : Piece {
    #region Monobehaviour
    private void Awake () {
    
    }
    #endregion

    #region Methods
    protected override bool CheckMovementRule(int newX, int newY) {
        // TODO: implement pawn movement
        return false;
    }
    #endregion
}
