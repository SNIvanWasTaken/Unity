using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private AudioSource ding;
    [SerializeField] AudioSource figureRules;
    private TitleScreen faderOut;

    // Start is called before the first frame update
    void Start()
    {
        ding = GetComponent<AudioSource>();
        faderOut = GetComponent<TitleScreen>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitPressed()
    {
        ding.Play();
        Application.Quit();
    }

    public void TutorialPressed()
    {
        ding.Play();
        figureRules.Play();
        faderOut.fading = true;
        faderOut.nextLvl = "Tutorial";
    }

    public void PlayPressed()
    {
        ding.Play();
        faderOut.fading = true;
        faderOut.nextLvl = "CharacterSelect";
    }

    public void SettingsPressed()
    {
        ding.Play();
    }
}
