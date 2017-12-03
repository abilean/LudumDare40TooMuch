using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletClicked : MonoBehaviour {

    private void OnMouseDown()
    {
        GameManager.Instance.WalletClicked();
        Destroy(this.gameObject);
    }
}
