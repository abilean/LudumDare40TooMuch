using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemLblText : MonoBehaviour {

    private Text _text;

    [SerializeField]
    private string ItemName = "Item";

    public GameManager.Items MyItem;

    

    void Awake()
    {
        _text = GetComponent<Text>();
        GameManager.Instance.OnItemClicked += HandleItemClicked;
        GameManager.Instance.OnLevelChanged += HandleChangeLevel;
    }

    private void HandleItemClicked(GameManager.Items item)
    {
        if (item == MyItem)
        {
            _text.color = Color.green;
            _text.text = "Found your "+MyItem.ToString()+"!";
        }
     }

    private void HandleChangeLevel(int lvl)
    {
        _text.color = Color.white;
        _text.text = "Find your "+MyItem.ToString()+"!";
    }
}
