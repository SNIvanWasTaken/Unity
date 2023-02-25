using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Este script le da funcionalidad al game manager.

    [SerializeField] Text ammoText;
    [SerializeField] Text hpText;
    [SerializeField] Text reloading;
    [SerializeField] Text gameOver;
    [SerializeField] Text nextStage;
    [SerializeField] Text gameFinished;
    private float disappear;
    private float appear = 2f;
    public int zombies = 8;
    [SerializeField] bool level1;

    public GameStatus gs;


    // Start is called before the first frame update
    //Al principio recogemos el game status y ponemos los valores iniciales de nuestras variables.
    void Start()
    {
        gs = FindObjectOfType<GameStatus>();
        hpText.text = "You have " + gs.hp;
        gameOver.enabled = false;
        reloading.enabled = false;
        nextStage.enabled = false;
        gameFinished.enabled = false;
        ammoText.text = gs.ammo + " / 18";
    }

    // Update is called once per frame
    //El texto de la municion y de las vidas se actualizará a tiempo real
    void Update()
    {
        hpText.text = "You have " + gs.hp + "hp";
        ammoText.text = gs.ammo + " / 18";
        if(reloading.enabled && Time.time >= disappear)
        {
            reloading.enabled = false;
        }
        //Aparecerá un texto de recargar cuando estemos recargando
        //Si todos los zombis han muerto, iremos al siguiente nivel o ganaremos, dependiendo si estamos en el nivel 1 o el 2

        if(zombies <= 0)
        {
            if (level1)
            {
                StartCoroutine(NextLevel());
            }
            else
            {
                StartCoroutine(FinishGame());
            }
        }
    }


    //Esta funcion daña al jugador y lo mata si tiene 0 vidas
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

    //Esta funcion hace el game over cuando el jugador muere
    private IEnumerator GameOver()
    {
        gameOver.enabled = true;
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.35f);
        Time.timeScale = 1;
        SceneManager.LoadScene("Intro");
    }

    //Esta función baja la munición y recarga cuando no tenga.
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

    //Esto recarga el arma y no te permite disparar hasta que se haya recargado.
    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(2f);
        gs.ammo = 18;
    }
    //Esto va al siguiente nivel
    private IEnumerator NextLevel()
    {
        nextStage.enabled = true;
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene2");
    }

    //Esto acaba la partida y te vuelve al inicio.
    private IEnumerator FinishGame()
    {
        gameFinished.enabled = true;
        Time.timeScale = 0.1F;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Intro");
    }
}
