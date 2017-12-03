using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalletCheckText : MonoBehaviour {

    private Text _text;

    void Awake()
    {
        _text = GetComponent<Text>();
        GameManager.Instance.OnWalletClicked += HandleWalletClicked;
        GameManager.Instance.OnLevelChanged += HandleChangeLevel;
    }

    private void HandleWalletClicked()
    {
        _text.color = Color.green;
        _text.text = "Found your Wallet!";
    }

    private void HandleChangeLevel(int lvl)
    {
        _text.color = Color.white;
        _text.text = "Find your Wallet!";
    }
}
