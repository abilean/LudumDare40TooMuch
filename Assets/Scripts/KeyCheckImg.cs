using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCheckImg : MonoBehaviour {

    /// <summary>
    /// reference to the animator on the game object
    /// </summary>
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        GameManager.Instance.OnKeysClicked += HandleKeyClicked;
        GameManager.Instance.OnLevelChanged += HandleChangeLevel;
    }

    private void HandleKeyClicked()
    {
        anim.SetBool("Completed", true);
    }

    private void HandleChangeLevel(int lvl)
    {
        anim.SetBool("Completed", false);
    }
}
