using UnityEngine;
using System;
using System.Collections;

public class GridGenerator : MonoBehaviour {
    #region Variables
    public static int       GridSize = 8;

    [SerializeField]
    private GameObject      fieldPrefab;
    public float            gridSpacing = 5;

    private FieldScript[,]  grid = new FieldScript[GridSize, GridSize];
    #endregion

    #region Monobehaviour
    private void Awake () {
        Generate();
    }
    
    private void Update () {
    
    }
    #endregion

    #region Methods
    public FieldScript GetGridCell(int x, int y) {
        return grid[x, y];
    }

    private void Generate() {
        float offset = ((GridSize - 1f) / (GridSize * 2f));

        // generate grid
        for (int i = 0; i < GridSize; ++i) {
            for (int j = 0; j < GridSize; ++j) {
                // spawn new cell
                GameObject go = Instantiate(fieldPrefab) as GameObject;
                go.transform.parent = transform;

                grid[i, j] = go.GetComponent<FieldScript>();
                grid[i, j].Set(i, j);

                // spread out cells
                Vector2 pos = new Vector2(
                    (((float)i / GridSize) - offset) * gridSpacing,
                    (((float)j / GridSize) - offset) * gridSpacing);
                Debug.Log(pos);
                go.transform.localPosition = pos;
            }            
        }
    }
    #endregion
}
