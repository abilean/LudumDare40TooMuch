using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysClicked : MonoBehaviour {



    private void OnMouseDown()
    {
        GameManager.Instance.KeysClicked();
        Destroy(this.gameObject);
    }
}
