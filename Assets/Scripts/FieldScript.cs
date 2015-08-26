using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Position {
    public int x;
    public int y;

    public Position(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public Position(Position pos) {
        this.x = pos.x;
        this.y = pos.y;
    }
}

public class FieldScript : MonoBehaviour {
    #region Variables
    public Position pos;

    public bool     occupied;
    public Piece    currentPiece;
    #endregion

    #region Monobehaviour
    private void Awake () {
    
    }
    #endregion

    #region Methods
    public void Initialize(int x, int y) {
        gameObject.name = "Cell " + x + "," + y;
        pos.x = x;
        pos.y = y;
    }

    public void Occupy(Piece piece) {
        occupied = true;
        currentPiece = piece;

        // TODO: set sprite based on type
    }

    public void Free() {
        occupied = false;
        currentPiece = null;
    }
    #endregion
}
