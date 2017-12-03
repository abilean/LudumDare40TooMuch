using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{

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

    /// <summary>
    /// Dictionary of the items to look for and if they have been found
    /// Value = true when found
    /// </summary>
    private Dictionary<string, bool> _itemsFound = new Dictionary<string, bool>()
    {
        {"Keys",false },
        {"Wallet", false },
        {"Phone", false }
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

    //TODO: cut this down with an enum or something, shouldn't have each things listed

    /// <summary>
    /// Thrown when player clicks the keys
    /// </summary>
    public Action OnKeysClicked = delegate { };

    /// <summary>
    /// Thrown when player clicks the wallet
    /// </summary>
    public Action OnWalletClicked = delegate { };

    /// <summary>
    /// Thrown when player clicks the phone
    /// </summary>
    public Action OnPhoneClicked = delegate { };

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



    /// <summary>
    /// Causes OnKeysClicked to be thrown
    /// </summary>
    public void KeysClicked()
    {
        if (OnKeysClicked != null)
            OnKeysClicked();

        _itemsFound["Keys"] = true;

        if (CheckWinRound())
           StartCoroutine( ChangeLevelWithCutScene(Level + 1,_sceneChangeDelay));
    }

    public void WalletClicked()
    {
        if (OnWalletClicked != null)
            OnWalletClicked();

        _itemsFound["Wallet"] = true;

        if (CheckWinRound())
            StartCoroutine(ChangeLevelWithCutScene(Level + 1, _sceneChangeDelay));
    }

    public void PhoneClicked()
    {
        if (OnPhoneClicked != null)
            OnPhoneClicked();

        _itemsFound["Phone"] = true;

        if (CheckWinRound())
            StartCoroutine(ChangeLevelWithCutScene(Level + 1, _sceneChangeDelay));
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
        _itemsFound["Keys"] = false;
        _itemsFound["Wallet"] = false;
        _itemsFound["Phone"] = false;
    }

    /// <summary>
    /// Changes the level
    /// </summary>
    /// <param name="lev">Level to be changed to</param>
    /// <param name="delay">The time to delay before executing</param>
    private IEnumerator ChangeLevelWithCutScene(int lvl, float delay)
    {
        //TODO: Add Cutscene
        yield return new WaitForSeconds(delay);
        Level = lvl;
    }

}
