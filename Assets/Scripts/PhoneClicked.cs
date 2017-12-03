using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneClicked : MonoBehaviour {

    private void OnMouseDown()
    {
        GameManager.Instance.PhoneClicked();
        Destroy(this.gameObject);
    }
}
