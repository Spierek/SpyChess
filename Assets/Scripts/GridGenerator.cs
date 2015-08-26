﻿using UnityEngine;
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
    public FieldScript GetField(int x, int y) {
        return grid[x, y];
    }
    public FieldScript GetField(Position pos) {
        return grid[pos.x, pos.y];
    }

    private void Generate() {
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
                go.transform.parent = transform;
            }            
        }
    }
    #endregion
}
