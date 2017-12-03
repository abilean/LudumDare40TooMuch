using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour {

    private AudioSource _audio;

    private Image _background;

    [SerializeField]
    private Image _postman;
    [SerializeField]
    private Image _upsMan;
    [SerializeField]
    private Image _speechPost;
    private Text _textPost;
    [SerializeField]
    private Image _speechUps;
    private Text _textUps;
    [SerializeField]
    private float _delay;

    public bool IsPlaying = false;

	// Use this for initialization
	void Start () {
        _audio = GetComponent<AudioSource>();
        _background = GetComponent<Image>();
        _textPost = _speechPost.gameObject.GetComponentInChildren<Text>();
        _textUps = _speechUps.gameObject.GetComponentInChildren<Text>();

        Cleanup();


	}
	
	public void StartCutscene()
    {
        IsPlaying = true;
        _background.enabled = true;
        StartCoroutine(RunCutscene());
    }


    private IEnumerator RunCutscene()
    {
        _audio.Play();

        yield return new WaitForSeconds(_delay);

        _postman.enabled = true;

        yield return new WaitForSeconds(_delay);

        _speechPost.enabled = true;
        _textPost.enabled = true;

        yield return new WaitForSeconds(_delay *2);

        _audio.Play();

        yield return new WaitForSeconds(_delay);

        _upsMan.enabled = true;

        yield return new WaitForSeconds(_delay);

        _speechUps.enabled = true;
        _textUps.enabled = true;

        yield return new WaitForSeconds(_delay*2);

        Cleanup();
        IsPlaying = false;
    }


    private void Cleanup()
    {
        _speechUps.enabled = false;
        _upsMan.enabled = false;
        _speechPost.enabled = false;
        _postman.enabled = false;
        _textPost.enabled = false;
        _textUps.enabled = false;
        _background.enabled = false;
    }


}
