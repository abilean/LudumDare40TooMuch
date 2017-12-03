using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private float _minX = -1f;
    [SerializeField]
    private float _maxX = 5f;
    [SerializeField]
    private float _minY = -2f;
    [SerializeField]
    private float _maxY = 3f;

    public int InitialSpawnNumberBackground = 50;
    public int InitialSpawnNumberMid = 20;
    public int InitialSpanwNumberFront = 5;

    public List<GameObject> _prefabs;

    public GameObject _keysPrefab;
    public GameObject _walletPrefab;
    public GameObject _phonePrefab;

    private void Awake()
    {
        GameManager.Instance.OnLevelChanged += HandleLevelChange;
    }

    
    void HandleLevelChange (int lvl) {
        if(lvl == 0)
        {
            return;
        }

        //Spawn all the clutter on different layers
        Spawn(_prefabs, InitialSpawnNumberBackground * lvl, "Background", -10);
        Spawn(_prefabs, InitialSpawnNumberMid * lvl, "Mid", -20);
        Spawn(_prefabs, InitialSpanwNumberFront * lvl, "Front", -40);

        //Spawn all the important items to find
        Spawn(_keysPrefab, "KeyObj", -30);
        Spawn(_walletPrefab, "KeyObj", -30);
        Spawn(_phonePrefab, "KeyObj", -30);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// creates random prefabs in random places on the screen area 
    /// </summary>
    /// <param name="prefabs">List of prefabs to make</param>
    /// <param name="count">How many to make</param>
    /// <param name="layer">Which sorting layer to put them on</param>
    /// <param name="z">the z coordinant for each item</param>
    private void Spawn(List<GameObject> prefabs, int count, string layer , int z)
    {
        //check for empty list
        if (prefabs == null || prefabs.Count == 0)
        {
            Debug.Log("No prefabs in _prefabs in spawner");
            return;
        }

        for(int i = 0; i < count; i++)
        {
            Spawn(prefabs[Random.Range(0, prefabs.Count)], layer, z);
        }
    }

    /// <summary>
    /// Spawns the prefab in a random location on the screen
    /// </summary>
    /// <param name="prefab">prefab to be spawned</param>
    /// <param name="layer">sorting layer to place it on</param>
    /// <param name="z">the z-axis coord</param>
    private void Spawn(GameObject prefab, string layer, int z)
    {
        if (prefab == null)
            return;

        GameObject tempObjRef;
        SpriteRenderer tempRender;

        float x = Random.Range(_minX, _maxX);
        float y = Random.Range(_minY, _maxY);

        tempObjRef = Instantiate(prefab,
            new Vector3(x, y, z),
            Quaternion.Euler(0, 0, Random.Range(-90, 90)),
            this.transform);
        tempRender = tempObjRef.GetComponent<SpriteRenderer>();

        tempRender.sortingLayerName = layer;
    }

}
