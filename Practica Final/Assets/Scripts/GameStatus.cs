using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    //De el game status se recoge la municion y la vida
    public int hp = 5;
    public int ammo = 18;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {

        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
}
