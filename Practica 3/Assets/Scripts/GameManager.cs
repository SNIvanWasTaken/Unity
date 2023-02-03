using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform portal;
    [SerializeField] Text soulsText;
    private int souls;
    [SerializeField] Text gameOver;
    [SerializeField] Text path;
    [SerializeField] Text lit;
    [SerializeField] AudioClip gameOverSFX;
    private float appear = 2f;
    private float disappear;
    private BoxCollider2D col;
    private SpriteRenderer s;


    // Start is called before the first frame update
    void Start()
    {
        souls = 5;
        lit.enabled = false;
        col = portal.gameObject.GetComponent<BoxCollider2D>();
        s = portal.gameObject.GetComponent<SpriteRenderer>();
        col.enabled = false;
        s.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lit.enabled && Time.time >= disappear)
        {
            lit.enabled = false;
        }
        if (path.enabled && Time.time >= disappear)
        {
            path.enabled = false;
        }

    }

    public void HurtPlayer()
    {
        souls--;
        soulsText.text = "You have " + souls + " souls remaining";
        FindObjectOfType<MovePlayer>().Respawn();
        if (souls <= 0)
        {
            gameOver.text = "Game over";
            AudioSource.PlayClipAtPoint(gameOverSFX, transform.position);
            StartCoroutine(BackToTitleScreen());
        }

    }

    public void HealPlayer()
    {
        souls++;
        soulsText.text = "You have " + souls + " souls remaining"; 
    }

    private IEnumerator BackToTitleScreen()
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.65f);
        Time.timeScale = 1;
        SceneManager.LoadScene("1.Intro");
    }

    public void BonfireLit(bool alreadyPlayed)
    {
        if (!alreadyPlayed)
        {
            lit.enabled = true;
            alreadyPlayed = true;
            disappear = Time.time + appear;
        }
        //lit.enabled = true;
        //disappear = Time.time + appear;
    }

}
