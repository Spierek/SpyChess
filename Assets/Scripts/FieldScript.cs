using UnityEngine;
using System.Collections;

public class FieldScript : MonoBehaviour {
    #region Variables
    public int x;
    public int y;
    #endregion

    #region Monobehaviour
    private void Awake () {
    
    }
    #endregion

    #region Methods
    public void Set(int x, int y) {
        gameObject.name = "Cell " + x + "," + y;
        this.x = x;
        this.y = y;
    }
    #endregion
}
