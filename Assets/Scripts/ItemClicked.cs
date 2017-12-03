using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClicked : MonoBehaviour {

    public GameManager.Items item;

    [SerializeField]
    private AudioSource _audio;


    private void OnMouseDown()
    {
        if (GameManager.Instance.IsPaused)
        {
            return;
        }

        if(_audio != null)
        {
            _audio.PlayOneShot(_audio.clip);
        }

        GameManager.Instance.ItemClicked(item);

        StartCoroutine(WaitToDestroy());
    }


    private IEnumerator WaitToDestroy()
    {
        while (_audio.isPlaying)
        {
            yield return new WaitForSeconds(0.001f);
        }

        Destroy(this.gameObject);
    }
}
