using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDrangleic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadDrangleic());
    }

    private IEnumerator LoadDrangleic()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("2.Drangleic's Castle");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
