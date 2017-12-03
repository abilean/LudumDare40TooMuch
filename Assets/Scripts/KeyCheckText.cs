using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCheckText : MonoBehaviour {

    private Text _text;

    void Awake()
    {
        _text = GetComponent<Text>();
        GameManager.Instance.OnKeysClicked += HandleKeyClicked;
        GameManager.Instance.OnLevelChanged += HandleChangeLevel;
    }

    private void HandleKeyClicked()
    {
        _text.color = Color.green;
        _text.text = "Found your Keys!";
    }

    private void HandleChangeLevel(int lvl)
    {
        _text.color = Color.white;
        _text.text = "Find your Keys!";
    }
}

