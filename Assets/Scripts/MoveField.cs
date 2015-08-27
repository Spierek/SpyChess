using UnityEngine;
using System;
using System.Collections;

public class MoveField : ActionField {
    #region Variables
    #endregion

    #region Monobehaviour
    #endregion

    #region Methods
    public override void Select(object sender, EventArgs e) {
        piece.Move(field);
    }
    #endregion
}
