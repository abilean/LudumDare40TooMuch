using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   public class PhoneClickedImg : MonoBehaviour
{

    /// <summary>
    /// reference to the animator on the game object
    /// </summary>
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        GameManager.Instance.OnPhoneClicked += HandlePhoneClicked;
        GameManager.Instance.OnLevelChanged += HandleChangeLevel;
    }

    private void HandlePhoneClicked()
    {
        anim.SetBool("Completed", true);
    }

    private void HandleChangeLevel(int lvl)
    {
        anim.SetBool("Completed", false);
    }
}