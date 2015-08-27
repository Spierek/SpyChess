using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TouchScript;
using TouchScript.Gestures;

public enum PieceType {
    Spy,
    Pawn,
    Rook,
    Knight,
    Bishop,
    Queen,
    King
}

public class Piece : MonoBehaviour {
    #region Variables
    public Position     currentPos;
    public PlayerType   player;
    public PieceType    type;
    public bool         selected;

    public Sprite[]     pieceSprites = new Sprite[7];

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer selectionRenderer;
    #endregion

    #region Monobehaviour
    private void Awake() {
        spriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        selectionRenderer = transform.Find("Selection").GetComponent<SpriteRenderer>();
        selectionRenderer.enabled = false;
    }

    private void Update() {
        // MOVEMENT TEST
        Position newPos = new Position(currentPos);
        bool moved = false;

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            newPos.y--; moved = true;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            newPos.y++; moved = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            newPos.x--; moved = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            newPos.x++; moved = true;
        }

        newPos.x = Mathf.Clamp(newPos.x, 0, BoardGenerator.GridSize - 1);
        newPos.y = Mathf.Clamp(newPos.y, 0, BoardGenerator.GridSize - 1);

        if (moved)
            Move(GameController.Instance.board.GetField(newPos));
    }

    private void OnEnable() {
        GetComponent<TapGesture>().Tapped += Select;
    }

    private void OnDisable() {
        GetComponent<TapGesture>().Tapped -= Select;
    }
    #endregion

    #region Methods
    public void Set(PlayerType p, PieceType t, Position pos) {
        player = p;
        currentPos = pos;
        SetType(t);

        transform.position = GameController.Instance.board.GetField(currentPos.x, currentPos.y).transform.position;
    }
    public void SetType(PieceType t) {
        type = t;
        spriteRenderer.sprite = pieceSprites[(int)t];
    }

    public void Select(object sender, EventArgs e) {
        // TODO: check if there's only one item selected
        selected = !selected;
        selectionRenderer.enabled = selected;

        if (selected) {
            GetMovementOptions();
        }
    }

    public void Move(FieldScript newField) {
        FieldScript currentField = GameController.Instance.board.GetField(currentPos.x, currentPos.y);

        currentField.Free();
        newField.Occupy(this);

        currentPos = newField.pos;

        // animate movement
        transform.DOMove(newField.transform.position, 0.5f).SetEase(Ease.InOutCubic);
    }

    public void Kill() {
        // TODO: remove from board
        // TODO: check if king
    }

    public List<Position> GetMovementOptions() {
        List<Position> moves = new List<Position>();
        BoardGenerator board = GameController.Instance.board;

        for (int i = 0; i < BoardGenerator.GridSize; ++i) {
            for (int j = 0; j < BoardGenerator.GridSize; ++j) {
                // add all viable moves to move list
                if (CheckMovement(board.GetField(i, j))) {
                    moves.Add(new Position(i, j));
                }
            }
        }

        return moves;
    }

    public bool CheckMovement(FieldScript field) {
        if (field == GameController.Instance.board.GetField(currentPos))
            return false;

        if (field.occupied && field.currentPiece.player == player)
            return false;

        if (!CheckMovementRules(field.pos))
            return false;

        return true;
    }

    // TODO: implement missing rules
    private bool CheckMovementRules(Position newPos) {
        switch (type) {
            default: return MovementRulesKing(newPos);
        }   
    }

    private bool MovementRulesKing(Position newPos) {
        if ((newPos.x == currentPos.x || newPos.x == currentPos.x - 1 || newPos.x == currentPos.x - 1)
            && (newPos.y == currentPos.y || newPos.y == currentPos.y - 1 || newPos.y == currentPos.y - 1))
            return true;

        return false;
    }
    #endregion
}
