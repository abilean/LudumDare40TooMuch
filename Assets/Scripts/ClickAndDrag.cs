using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour {

    private void OnMouseDrag()
    {
        Vector3 mPosition = Input.mousePosition;
        mPosition = Camera.main.ScreenToWorldPoint(mPosition);
        this.transform.position = new Vector3(mPosition.x, mPosition.y, this.transform.position.z);
    }


}
