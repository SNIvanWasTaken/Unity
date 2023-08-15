using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    //List of strings for the dialogue
    private List<string> dialogue = new List<string>();
    [SerializeField] Text text;
    private int convoNum = 0;

    //FaderOut
    [SerializeField] Image fader;
    private float fadeSpd = 0.8f;
    private bool fading = false;
    private bool transition = false;
    [SerializeField] string nextLvl;


    // Start is called before the first frame update
    void Start()
    {
        //Adds evey dialogue line
        dialogue.Add("");
        dialogue.Add("Evelyn: How much is it left? Feels like it will never end!");
        dialogue.Add("Fabri: It has been 8 hours. Port Elgado was way way further than I anticipated, my apologies.");
        dialogue.Add("Patrick: They are always so apologetic, don't sweat it fella.");
        dialogue.Add("William: We are arriving soon, so get ready to disembark in around 30 minutes.");
        dialogue.Add("Evelyn: Oh shit, I need to sharpen my axe, why do I always leave these things for the end?!");
        dialogue.Add("Patrick: Hah, I love using bows. I ain't worryin' about any of that.");
        dialogue.Add("Evelyn: Yeah yeah Patrick you love bows we get it.");
        dialogue.Add("Fabri: They at it again. Sigh...");
        dialogue.Add("Patrick: Well, if you didn't choose the INFERIOR weapon you wouldn't have to sharpen shit mate.");
        dialogue.Add("Evelyn: Do you want to be stabbed today? Is that what you want?");
        dialogue.Add("William: Can you two babies behave for once?");
        dialogue.Add("Fabri: Haha, some things never change!");
        dialogue.Add("Evelyn: What are they laughing at now?!");
        dialogue.Add("Fabri: It has been so long since I've been in Elgado. This place always brings me peace.");
        dialogue.Add("Evelyn: I can't wait to sell our bounty and have a drink in 'Drink and Flink'.");
        dialogue.Add("Patrick: Yeeeah you definitely wanna be there cause of the drinks huh?");
        dialogue.Add("Evelyn: It's not my fault that the woman that runs it is so hot and beautiful and kind and-");
        dialogue.Add("Fabri: I am not interested in your desire to have sexual intercourse with other women.");
        dialogue.Add("Patrick: Why are you always so cold, Fabri?");
        dialogue.Add("William: To be honest, I really don't care either.");
        dialogue.Add("Evelyn: These scallywags won't give me a break!");
        dialogue.Add("William: Uuuh... Guys we have an issue.");
        dialogue.Add("Fabri: What is it?");
        dialogue.Add("William: If my eyes don't decieve me, there are some thugs on the beach we are disembarking on.");
        dialogue.Add("Patrick: I don't know if yo eyes decieve ya but mine sure ain't. Guys, we gotta get ready for battle.");
        dialogue.Add("Evelyn: Alright, It's time to give them a deadly big 'Welcome'.");
        dialogue.Add("Fabri: Man I really don't like battle.");
        text.text = dialogue[0];
    }

    // Update is called once per frame
    void Update()
    {
        //28
        //Starts fading to next scene or goes to next dialogue line.
        if (Input.anyKeyDown)
        {
            convoNum++;
            if (convoNum != 28)
            {
                text.text = dialogue[convoNum];
            }
            else
            {
                fading = true;
            }
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
