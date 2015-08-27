using UnityEngine;
using System;
using System.Collections;

public class AttackField : ActionField {
    #region Variables
    public Piece    targetPiece;
    #endregion

    #region Monobehaviour
    private void Awake () {
    
    }
    
    private void Update () {
    
    }
    #endregion

    #region Methods
    public override void Set(Piece piece, FieldScript field) {
        base.Set(piece, field);
        targetPiece = field.currentPiece;
    }

    public override void Select(object sender, EventArgs e) {
        targetPiece.Kill();
        piece.Move(field);
    }
    #endregion
}
