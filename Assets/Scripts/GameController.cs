using UnityEngine;
using System;
using System.Collections;

public enum PlayerType {
    White,
    Black
}

public class GameController : MonoBehaviour {
    #region Variables
    public static GameController Instance;

    public GridGenerator grid;
    #endregion

    #region Monobehaviour
    private void Awake () {
        Instance = this;
    }
    
    private void Update () {
    
    }
    #endregion

    #region Methods
    #endregion
}
