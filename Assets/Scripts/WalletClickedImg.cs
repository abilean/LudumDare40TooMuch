using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletClickedImg : MonoBehaviour
{

    /// <summary>
    /// reference to the animator on the game object
    /// </summary>
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        GameManager.Instance.OnWalletClicked += HandleWalletClicked;
        GameManager.Instance.OnLevelChanged += HandleChangeLevel;
    }

    private void HandleWalletClicked()
    {
        anim.SetBool("Completed", true);
    }

    private void HandleChangeLevel(int lvl)
    {
        anim.SetBool("Completed", false);
    }
}
