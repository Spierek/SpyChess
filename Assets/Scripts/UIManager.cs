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
    public Button declarationButton;
    public Button declarationRookButton;
    public Button declarationKnightButton;
    public Button declarationBishopButton;
    public Button declarationQueenButton;
    #endregion

    #region Monobehaviour
    private void Start () {
        UpdateTopUI(GameController.Instance.turnCounter, GameController.Instance.currentPlayer);
        SetDeclarationButton(false);
        SetDeclarationTypeButtons(false);
    }
    
    private void OnEnable() {
        GameController.OnNextTurn += UpdateTopUI;
        GameController.OnPieceSelection += SetDeclarationButton;
    }

    private void OnDisable() {
        GameController.OnNextTurn -= UpdateTopUI;
        GameController.OnPieceSelection -= SetDeclarationButton;
    }
    #endregion

    #region Methods
    private void UpdateTopUI(int turns, PlayerType type) {
        turnCounter.text = turns.ToString();
        currentPlayerIndicator.text = (type == PlayerType.White) ? "White" : "Black";
    }

    public void SetDeclarationButton(bool set) {
        declarationButton.interactable = set;
    }

    // TODO: check player type availability
    public void SetDeclarationTypeButtons(bool set) {
        declarationRookButton.interactable = set;
        declarationKnightButton.interactable = set;
        declarationBishopButton.interactable = set;
        declarationQueenButton.interactable = set;
    }
    #endregion
}
