using UnityEngine;
using System;
using System.Collections;

public class BoardGenerator : MonoBehaviour {
    #region Variables
    public static int       GridSize = 8;

    [SerializeField]
    private GameObject      fieldPrefab;
    [SerializeField]
    private GameObject      piecePrefab;

    public float            gridSpacing = 5.75f;

    private FieldScript[,]  grid = new FieldScript[GridSize, GridSize];
    #endregion

    #region Monobehaviour
    private void Awake () {
        GenerateGrid();
        SetupPieces();
    }

    private void Start() {
    }
    
    private void Update () {
    
    }
    #endregion

    #region Methods
    public FieldScript GetField(int x, int y) {
        return grid[x, y];
    }
    public FieldScript GetField(Position pos) {
        return grid[pos.x, pos.y];
    }

    private void GenerateGrid() {
        Transform dir = transform.Find("Grid");
        float offset = ((GridSize - 1f) / (GridSize * 2f));

        // generate grid
        for (int i = 0; i < GridSize; ++i) {
            for (int j = 0; j < GridSize; ++j) {
                // spawn new field
                GameObject go = Instantiate(fieldPrefab) as GameObject;

                grid[i, j] = go.GetComponent<FieldScript>();
                grid[i, j].Initialize(i, j);

                // spread out cells
                Vector2 pos = new Vector2(
                    (((float)i / GridSize) - offset) * gridSpacing,
                    -(((float)j / GridSize) - offset) * gridSpacing);
                go.transform.localPosition = pos;
                go.transform.parent = dir;
            }            
        }
    }

    private void SetupPieces() {
        Transform dir = transform.Find("Pieces");
        // spawn spies
        for (int i = 0; i < 2; i++) {
            for (int j = 0; j < GridSize; j++) {
                SpawnPiece(PlayerType.Black, PieceType.Spy, new Position(j, i), dir);
                SpawnPiece(PlayerType.White, PieceType.Spy, new Position(j, GridSize - i - 1), dir);
            }        
        }

        // exception: set king pieces
        GameController.Instance.board.GetField(3, 0).currentPiece.SetType(PieceType.King);
        GameController.Instance.board.GetField(4, 7).currentPiece.SetType(PieceType.King);
    }

    private void SpawnPiece(PlayerType p, PieceType t, Position pos, Transform parent) {
        GameObject go = Instantiate(piecePrefab) as GameObject;
        Piece piece = go.GetComponent<Piece>();
        go.transform.parent = parent;
        
        piece.Set(p, t, pos);
        GameController.Instance.board.GetField(pos).Occupy(piece);
    }
    #endregion
}
