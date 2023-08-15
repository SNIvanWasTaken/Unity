using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI start;
    private AudioSource sword;
    [SerializeField] string nextLvl;

    //FaderOut
    [SerializeField] Image fader;
    private float fadeSpd = 0.8f;
    private bool fading = false;
    private bool transition = false;


    // Start is called before the first frame update
    void Start()
    {
        sword = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            sword.Play();
            fading = true;
        }

        if (fading)
        {
            Color color = fader.color;
            color.a += fadeSpd * Time.deltaTime;
            fader.color = color;

            if (fader.color.a >= 1)
            {
                fading = false;
                transition = true;
            }
        }
        if (transition)
        {
            StartNextScene(nextLvl);
        }
    }
    public void StartNextScene(string nextLvl)
    {
        SceneManager.LoadScene(nextLvl);
    }

}
