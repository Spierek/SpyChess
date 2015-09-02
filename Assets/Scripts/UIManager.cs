using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    #region Variables
    [Header("Top UI")]
    public Text turnCounter;
    public Text currentPlayerIndicator;

    [Header("Bottom UI")]
    public Button declareButton;
    #endregion

    #region Monobehaviour
    private void Start () {
        UpdateTopUI(GameController.Instance.turnCounter, GameController.Instance.currentPlayer);
    }
    
    private void Update () {
    
    }

    private void OnEnable() {
        GameController.OnNextTurn += UpdateTopUI;
    }

    private void OnDisable() {
        GameController.OnNextTurn -= UpdateTopUI;
    }
    #endregion

    #region Methods
    private void UpdateTopUI(int turns, PlayerType type) {
        turnCounter.text = turns.ToString();
        currentPlayerIndicator.text = (type == PlayerType.White) ? "White" : "Black";
    }
    #endregion
}
