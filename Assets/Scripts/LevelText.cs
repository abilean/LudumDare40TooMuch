using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour {

    private Text _lvlText;

    private void Awake()
    {
        _lvlText = GetComponent<Text>();
        GameManager.Instance.OnLevelChanged += HandleLevelChange;
    }
    
    private void HandleLevelChange(int lvl)
    {
        _lvlText.text = lvl.ToString();
    }
}
