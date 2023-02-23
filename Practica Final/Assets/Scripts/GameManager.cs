using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text ammoText;
    [SerializeField] Text hpText;
    [SerializeField] Text reloading;
    [SerializeField] Text gameOver;
    private float disappear;
    private float appear = 2f;

    public GameStatus gs;


    // Start is called before the first frame update
    void Start()
    {
        gs = FindObjectOfType<GameStatus>();
        hpText.text = "You have " + gs.hp;
        gameOver.enabled = false;
        reloading.enabled = false;
        ammoText.text = gs.ammo + " / 18";
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "You have " + gs.hp;
        ammoText.text = gs.ammo + " / 18";
        if(reloading.enabled && Time.time >= disappear)
        {
            reloading.enabled = false;
        }
    }
    public void HurtPlayer()
    {
        if(gs.hp > 0) 
        {
            gs.hp--;
        }
        else
        {
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator GameOver()
    {
        gameOver.enabled = true;
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.65f);
        Time.timeScale = 1;
        SceneManager.LoadScene("Intro");
    }

    public void DecreaseAmmo()
    {
        if(gs.ammo > 0)
        {
            gs.ammo--;
        }
        else
        {
            reloading.enabled = true;
            disappear = Time.time + appear;
            StartCoroutine(Reload());
        }
    }
    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(2f);
        gs.ammo = 18;
    }
    private IEnumerator NextLevel()
    {

    }
}
