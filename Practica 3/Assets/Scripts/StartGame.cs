using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Este script inicia el primer nivel cuando se le da al bot�n
    public void StartLevel()
    {
        SceneManager.LoadScene("Loading1");
    }
}