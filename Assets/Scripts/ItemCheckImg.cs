using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCheckImg : MonoBehaviour {

    /// <summary>
    /// reference to the animator on the game object
    /// </summary>
    private Animator anim;

    [Tooltip("The Item for this check")]
    public GameManager.Items MyItem;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        GameManager.Instance.OnItemClicked += HandleItemClicked;
        GameManager.Instance.OnLevelChanged += HandleChangeLevel;
    }

    /// <summary>
    /// If it's the correct Item that was clicked, activates the check
    /// </summary>
    /// <param name="item"></param>
    private void HandleItemClicked(GameManager.Items item)
    {
        if(item == MyItem)
            anim.SetBool("Completed", true);
    }

    private void HandleChangeLevel(int lvl)
    {
        anim.SetBool("Completed", false);
    }
}
