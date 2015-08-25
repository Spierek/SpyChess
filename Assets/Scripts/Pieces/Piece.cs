using UnityEngine;
using System;
using System.Collections;

public abstract class Piece {
    #region Variables
    public Position     currentPos;
    public PlayerType   player;
    #endregion

    #region Methods
    public abstract void        Move(int x, int y);
    public abstract Position[]  GetMovementOptions();

    public virtual void Kill() {
        // TODO: remove from board
        // TODO: check if king
    }

    // checks if planned move doesn't go out of bounds / to a field already occupied by unit from same team
    public bool MovementCheck(int newX, int newY) {
        if (newX < 0 || newX > GridGenerator.GridSize - 1 || newY < 0 || newY > GridGenerator.GridSize - 1)
            return false;

        FieldScript field = GameController.Instance.grid.GetField(newX, newY);
        if (field.occupied && field.currentPiece.player == player)
            return false;

        return true;
    }
    #endregion
}
