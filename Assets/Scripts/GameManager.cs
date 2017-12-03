using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{

    public enum Items 
    {
        Keys,
        Wallet,
        Phone
    };

    /// <summary>
    /// The actual score, do not access variable directly, Use Score
    /// </summary>
    [SerializeField]
    private int _score = 0;

    /// <summary>
    /// indicates if the game is paused
    /// </summary>
    private bool _paused = false;

    [SerializeField]
    private float _sceneChangeDelay = 2f;

    /// <summary>
    /// Which level the Player is on, 0 is Main Menu
    /// </summary>
    private int _level = 0;

    [SerializeField]
    private CutsceneController _cutscene;

    /// <summary>
    /// Dictionary of the items to look for and if they have been found
    /// Value = true when found
    /// </summary>
    private Dictionary<Items, bool> _itemsFound = new Dictionary<Items, bool>()
    {
        {Items.Keys,false },
        {Items.Wallet, false },
        {Items.Phone, false }
    };



    public int Score
    {
        get { return _score; }
        private set
        {
            _score = value;
            if (OnScoreChanged != null)
                OnScoreChanged(_score);
        }
    }

    public bool IsPaused
    {
        get { return _paused; }
    }

    public int Level
    {
        get { return _level; }
        private set
        {
            _level = value;
            InitNewLevel();
            if (OnLevelChanged != null)
                OnLevelChanged(_level);
        }
    }

    /// <summary>
    /// Event thrown when score changed
    /// Int is the new score
    /// </summary>
    public Action<int> OnScoreChanged = delegate { };

    /// <summary>
    /// event thrown when Level changes 
    /// Int is the new Level
    /// </summary>
    public Action<int> OnLevelChanged = delegate { };


    /// <summary>
    /// Event thrown when the game becomes paused
    /// bool = true when paused
    /// bool = false when unpaused
    /// </summary>
    public Action<bool> OnGamePausedChg = delegate { };

    /// <summary>
    /// Thrown when player clicks an Item is clicked
    /// </summary>
    public Action<Items> OnItemClicked = delegate { };



    protected GameManager()
    {

    }

    // Use this for initialization
    void Start () {
        Score = 0;
        Level = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IncreaseScore(int amount)
    {
        Score += amount;
    }

    public void DecreaseScore(int amount)
    {
        Score -= amount;
    }

    public void ItemClicked(Items item)
    {
        if (OnItemClicked != null)
            OnItemClicked(item);

        _itemsFound[item] = true;

        if (CheckWinRound())
        {
            _cutscene.StartCutscene();
            StartCoroutine(ChangeLevelWithCutScene(Level + 1, _sceneChangeDelay));
        }
    }




    /// <summary>
    /// Starts the game back at level 1, resets anything that need to be reset
    /// </summary>
    public void StartNewGame()
    {
        Score = 0;
        Level = 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;

        _paused = true;

        if (OnGamePausedChg != null)
            OnGamePausedChg(true);

    }

    /// <summary>
    /// Closes menu and puts game back into motion
    /// </summary>
    public void UnPauseGame()
    {

        Time.timeScale = 1;

        _paused = false;

        if (OnGamePausedChg != null)
            OnGamePausedChg(false);
    }

    /// <summary>
    /// Checks to see if all the items have been found
    /// </summary>
    /// <returns>If all items found returns true</returns>
    private bool CheckWinRound()
    {
        foreach(var win in _itemsFound.Values)
        {
            if (win == false)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Sets time scale to 1 
    /// sets all items found to false
    /// </summary>
    private void InitNewLevel()
    {
        Time.timeScale = 1;

        _itemsFound[Items.Keys] = false;
        _itemsFound[Items.Phone] = false;
        _itemsFound[Items.Wallet] = false;
        
    }

    /// <summary>
    /// Changes the level
    /// </summary>
    /// <param name="lev">Level to be changed to</param>
    /// <param name="delay">The time to delay before executing</param>
    private IEnumerator ChangeLevelWithCutScene(int lvl, float delay)
    {
      
        while (_cutscene.IsPlaying)
        {
            yield return new WaitForSeconds(0.1f);
                
        }
        Level = lvl;

    }

}
