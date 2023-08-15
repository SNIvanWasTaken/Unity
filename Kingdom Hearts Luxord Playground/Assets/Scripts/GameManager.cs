using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Songs
    [SerializeField] AudioSource twtnwSong;
    [SerializeField] AudioSource deepDrive;
    //Bools for song logic
    private bool songFadeOut = false;
    private bool songFadeIn = false;
    private bool danger = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Call to change the music when someone is in danger
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            songFadeOut = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            songFadeIn = true;
        }
        StartCoroutine(SongSwap(0.5f, songFadeIn, songFadeOut));
    }

    //Logic for the music swap
    private IEnumerator SongSwap(float wait, bool sFadeIn, bool sFadeOut)
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
}
