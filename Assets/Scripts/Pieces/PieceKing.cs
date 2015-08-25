using UnityEngine;
using System;
using System.Collections;

public class PieceKing : Piece {
    #region Monobehaviour
    private void Awake () {
    
    }
    #endregion

    #region Methods
    // TODO: check king movement
    protected override bool CheckMovementRule(int newX, int newY) {
        if ((newX == currentPos.x || newX == currentPos.x - 1 || newX == currentPos.x - 1)
            && (newY == currentPos.y || newY == currentPos.y - 1 || newY == currentPos.y - 1))
            return true;

        return false;
    }
    #endregion
}
