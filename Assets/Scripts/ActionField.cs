using UnityEngine;
using System;
using System.Collections;
using TouchScript;
using TouchScript.Gestures;

public abstract class ActionField : MonoBehaviour {
    #region Variables
    public Piece piece;
    public FieldScript field;
    #endregion

    #region Monobehaviour
    private void OnEnable() {
        GetComponent<TapGesture>().Tapped += Select;
    }

    private void OnDisable() {
        GetComponent<TapGesture>().Tapped -= Select;
    }
    #endregion

    #region Methods
    public virtual void Set(Piece piece, FieldScript field) {
        this.piece = piece;
        this.field = field;

        transform.position = field.transform.position;
    }

    public abstract void Select(object sender, EventArgs e);
    #endregion
}
