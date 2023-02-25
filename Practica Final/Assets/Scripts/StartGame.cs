using System;
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
        StartCoroutine(StartLevel());
    }

    //Esto empieza el juego despues de la pantalla de inicio
    private IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("SampleScene");
    }
}
