using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour {

    private AudioSource _audio;

    private bool _playedAudio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnMouseDrag()
    {
        if (GameManager.Instance.IsPaused)
        {
            return;
        }

        Vector3 mPosition = Input.mousePosition;
        mPosition = Camera.main.ScreenToWorldPoint(mPosition);
        this.transform.position = new Vector3(mPosition.x, mPosition.y, this.transform.position.z);

        if(_audio != null && _playedAudio == false)
        {
            _audio.Play();
            _playedAudio = true;
        }
    }

    private void OnMouseUp()
    {
        _playedAudio = false;
    }


}
