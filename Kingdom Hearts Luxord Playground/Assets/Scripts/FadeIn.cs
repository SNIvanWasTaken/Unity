using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField] Image fader;
    private float fadeSpd = 0.8f;
    public bool fading = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            Color color = fader.color;
            color.a -= fadeSpd * Time.deltaTime;
            fader.color = color;
            if (fader.color.a <= 0)
            {
                fading = false;
            }
        }
    }
}
