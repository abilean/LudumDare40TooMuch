using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HideOnPause : MonoBehaviour {

    private Image _image;

    private void Awake()
    {
        GameManager.Instance.OnGamePausedChg += HandleGamePause;

        _image = this.gameObject.GetComponent<Image>();
    }

    private void HandleGamePause(bool paused)
    {
        if (paused)
        {
            _image.enabled = false;
        }
        else
        {
            _image.enabled = true;
        }
    }
}
