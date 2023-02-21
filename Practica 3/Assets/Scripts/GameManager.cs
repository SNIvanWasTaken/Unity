using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text soulsText;
    [SerializeField] Text path;
    [SerializeField] GameObject portal;
    private int totalPickups;
    private int souls;
    [SerializeField] Text gameOver;
    [SerializeField] Text lit;
    [SerializeField] AudioClip gameOverSFX;
    private float appear = 2f;
    private float disappear;
    private int counter;
    private int healCounter;
    [SerializeField] bool isEnding;

    private GameStatus gs;


    // Start is called before the first frame update
    void Start()
    {
        totalPickups = GameObject.FindObjectsOfType<Pickups>().Length;
        souls = 5;
        lit.enabled = false;
        counter = 0;
        healCounter = 0;

        gs = FindObjectOfType<GameStatus>();
        souls = gs.souls;
        healCounter = gs.healCounter;
        soulsText.text = "You have " + gs.souls + " souls remaining";

    }

    public void addPickup() 
    {
        healCounter++;
        counter++;
        if (counter >= totalPickups) 
        {
            path.enabled = true;
            portal.GetComponent<SpriteRenderer>().enabled = true;
            portal.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lit.enabled && Time.time >= disappear)
        {
            if (!isEnding)
            {
                lit.enabled = false;
            }
        }
        if (healCounter >= 5)
        {
            HealPlayer();
            healCounter = 0;
        }
    }

    public void HurtPlayer()
    {
        gs.souls--;
        soulsText.text = "You have " + gs.souls + " souls remaining";
        FindObjectOfType<MovePlayer>().Respawn();
        if (gs.souls <= 0)
        {
            gameOver.text = "Game over";
            AudioSource.PlayClipAtPoint(gameOverSFX, transform.position);
            StartCoroutine(BackToTitleScreen());
        }

    }

    public void HealPlayer()
    {
        gs.souls++;
        soulsText.text = "You have " + gs.souls + " souls remaining"; 
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
    }

}
