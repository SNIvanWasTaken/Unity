using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Songs
    [SerializeField] AudioSource twtnwSong;
    [SerializeField] AudioSource deepDrive;

    //Bools for song logic
    private bool songFadeOut = false;
    private bool songFadeIn = false;
    private bool danger = false;

    //Texts
    [SerializeField] Text timerTxt;
    [SerializeField] Text cardsLeftTxt;
    [SerializeField] Text hp1Txt;
    [SerializeField] Text hp2Txt;

    //Numbers
    private int turnCount = 1;
    private float timer = 181;
    private int cardsLeft = 20;
    private int hp1 = 20;
    private int hp2 = 20;
    private int mana1 = 0;
    private int mana2 = 0;
    private int energy1 = -1;
    private int energy2 = -1;
    private int maxMP1 = -1;
    private int maxMP2 = -1;

    //Bools
    private bool changingTurn = false;
    private bool player1Turn = true;

    //Visuals
    [SerializeField] List<GameObject> mp1Images = new List<GameObject>();
    [SerializeField] List<GameObject> mp2Images = new List<GameObject>();
    [SerializeField] List<GameObject> energy1Images = new List<GameObject>();
    [SerializeField] List<GameObject> energy2Images = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        RefillResources();
    }

    // Update is called once per frame
    void Update()
    {
        //Call to change the music when someone is in danger
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            songFadeOut = true;
            //mana1++;
            //energy1++;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            songFadeIn = true;
            mana1--;
            energy1--;
        }
        ManageResources();
        StartCoroutine(SongSwap(0.5f));

        //Text setters
        if (!changingTurn)
        {
            timer -= Time.deltaTime;
            timerTxt.text = timer.ToString();
            cardsLeftTxt.text = cardsLeft.ToString();
            hp1Txt.text = hp1.ToString();
            hp2Txt.text = hp2.ToString();
        } 
    }

    //Logic for the music swap
    private IEnumerator SongSwap(float wait)
    {
        if (songFadeOut)
        {
            if (twtnwSong.volume > 0)
            {
                twtnwSong.volume -= 0.0005f;
            }
            else
            {
                songFadeOut = false;
                deepDrive.Play();
            }
        }
        if (songFadeIn)
        {
            deepDrive.Stop();
            yield return new WaitForSeconds(wait);
            if (twtnwSong.volume <= 0.1)
            {
                twtnwSong.volume += 0.0005f;
            }
            else
            {
                songFadeIn = false;
            }
        }
    }
    public void NextTurn()
    {
        timer = 180;
        if (player1Turn)
        {
            player1Turn = false;
        }
        else
        {
            player1Turn = true;
            if (turnCount < 10) 
            {
                turnCount++;
            }
        }
        DrawCard();
        RefillResources();
    }
    private void DrawCard()
    {
        if (player1Turn)
        {

        }
        else
        {

        }
    }
    private void RefillResources()
    {
        if (player1Turn)
        {
            if(maxMP1 < 10)
            {
                maxMP1++;
            }
            mana1 = maxMP1;
            if (energy1 < 5)
            {
                energy1++;
            }
        }
        else
        {
            if(maxMP2 < 10)
            {
                maxMP2++;
            }
            mana2 = maxMP2;
            if (energy2 < 5)
            {
                energy2++;
            }
        }
    }
    private void ManageResources()
    {
        int i = 0;
        foreach(GameObject mp in mp1Images)
        {
            if(i <= mana1)
            {
                mp1Images[i].SetActive(true);
                i++;
            }
            else
            {
                mp1Images[i].SetActive(false);
            }
        }
        i = 0;
        foreach (GameObject mp in mp2Images)
        {
            if (i <= mana2)
            {
                mp2Images[i].SetActive(true);
                i++;
            }
            else
            {
                mp2Images[i].SetActive(false);
            }
        }
        i = 0;
        foreach (GameObject en in energy1Images)
        {
            if (i <= energy1)
            {
                energy1Images[i].SetActive(true);
                i++;
            }
            else
            {
                energy1Images[i].SetActive(false);
            }
        }
        i = 0;
        foreach (GameObject en in energy2Images)
        {
            if (i <= energy2)
            {
                energy2Images[i].SetActive(true);
                i++;
            }
            else
            {
                energy2Images[i].SetActive(false);
            }
        }
    }
}
