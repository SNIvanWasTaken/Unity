using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterGraveyard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("4.Keyblade Graveyard");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
