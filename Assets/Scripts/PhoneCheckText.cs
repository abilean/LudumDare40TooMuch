using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCheckText : MonoBehaviour {

    private Text _text;

    void Awake()
    {
        _text = GetComponent<Text>();
        GameManager.Instance.OnPhoneClicked += HandlePhoneClicked;
        GameManager.Instance.OnLevelChanged += HandleChangeLevel;
    }

    private void HandlePhoneClicked()
    {
        _text.color = Color.green;
        _text.text = "Found your Phone!";
    }

    private void HandleChangeLevel(int lvl)
    {
        _text.color = Color.white;
        _text.text = "Find Your Phone";
    }
}
