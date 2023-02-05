using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndgameTrigger : MonoBehaviour
{
    private float appear = 1f;
    private float disappear;
    private bool back = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= disappear)
        {
            FindObjectOfType<MovePlayer>().animator.SetBool("End1", false);
            FindObjectOfType<MovePlayer>().animator.SetBool("End2", true);
            if (back)
            {
                StartCoroutine(BackToTitleScreen());
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<MovePlayer>().velocidad = 0f;
            FindObjectOfType<MovePlayer>().velocidadSalto = 0f;
            FindObjectOfType<MovePlayer>().animator.SetBool("End1", true);
            disappear = Time.time + appear;
            back = true;
        }
    }
    private IEnumerator BackToTitleScreen()
    {
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene("1.Intro");
    }
}
