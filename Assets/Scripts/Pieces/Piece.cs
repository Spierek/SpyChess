using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public abstract class Piece {
    #region Variables
    public Position     currentPos;
    public PlayerType   player;
    #endregion

    #region Methods
    public void Move(FieldScript newField) {
        FieldScript currentField = GameController.Instance.grid.GetField(currentPos.x, currentPos.y);

        currentField.Free();
        newField.Occupy(this);

        currentPos.x = newField.pos.x;
        currentPos.y = newField.pos.y;
    }

    public virtual void Kill() {
        // TODO: remove from board
        // TODO: check if king
    }

    public List<Position> GetMovementOptions() {
        List<Position> moves = new List<Position>();
        GridGenerator grid = GameController.Instance.grid;

        for (int i = 0; i < GridGenerator.GridSize; ++i) {
            for (int j = 0; j < GridGenerator.GridSize; ++j) {
                // add all viable moves to move list
                if (CheckMovement(grid.GetField(i, j))) {
                    moves.Add(new Position(i, j));
                }
            }
        }

        return moves;
    }

    public bool CheckMovement(FieldScript field) {
        if (field == GameController.Instance.grid.GetField(currentPos))
            return false;

        if (field.occupied && field.currentPiece.player == player)
            return false;

        if (!CheckMovementRule(field.pos.x, field.pos.y))
            return false;

        return true;
    }

    // overloadable method for child classes
    // used to check if a certain pawn type can reach the destination
    protected abstract bool CheckMovementRule(int newX, int newY);
    #endregion
}
