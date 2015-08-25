using UnityEngine;
using System.Collections;

public struct Position {
    public int x;
    public int y;
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
    public void Set(int x, int y) {
        gameObject.name = "Cell " + x + "," + y;
        pos.x = x;
        pos.y = y;
    }
    #endregion
}
