using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UI.CanvasScaler;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    //FaderOut
    [SerializeField] Image fader;
    private float fadeSpd = 0.8f;
    private bool fading = false;
    private bool transition = false;
    [SerializeField] string nextLvl;

    //Allies
    [SerializeField] Evelyn eve;
    [SerializeField] Evelyn fab;
    [SerializeField] Evelyn ella;
    [SerializeField] Evelyn will;
    [SerializeField] Evelyn pat;

    //Pointer
    [SerializeField] PointerTrigger pointer;

    //Interface
    [SerializeField] GameObject charInfo;
    [SerializeField] GameObject waitMenu;
    [SerializeField] GameObject attackMenu;
    [SerializeField] GameObject healMenu;
    [SerializeField] GameObject forecast;
    [SerializeField] GameObject levelPanel;
    [SerializeField] GameObject expPanel;
    private bool charInfoShown = false;

    [SerializeField] Text charName;
    [SerializeField] Text charSquareName;
    [SerializeField] Text charDesc;
    [SerializeField] Text charLikes;
    [SerializeField] Text charDislikes;
    [SerializeField] Text charClass;
    [SerializeField] Text charCurrHp;
    [SerializeField] Text charMaxHp;
    [SerializeField] Text charStr;
    [SerializeField] Text charMag;
    [SerializeField] Text charSkl;
    [SerializeField] Text charSpd;
    [SerializeField] Text charDef;
    [SerializeField] Text charMov;
    [SerializeField] Text charHit;
    [SerializeField] Text charAvoid;
    [SerializeField] Text charAtk;
    [SerializeField] Text charEXP;
    [SerializeField] Text exp;
    
    [SerializeField] Text fAlly;
    [SerializeField] Text fAllyHp;
    [SerializeField] Text fAllyDmg;
    [SerializeField] Text fAllyDouble;
    [SerializeField] Text fAllyHit;
    [SerializeField] Text fAllyCrit;
    [SerializeField] Text fEnem;
    [SerializeField] Text fEnemHp;
    [SerializeField] Text fEnemDmg;
    [SerializeField] Text fEnemHit;
    [SerializeField] Text fEnemCrit;

    private Evelyn currentChar;

    [SerializeField] Text currentTile;
    [SerializeField] Text tileDesc;

    private Vector2 initialPos;
    private Vector2 limitPos;
    private bool moving = false;

    private bool menuOut;
    private bool waitOut;
    private bool attackOut;
    private bool healOut;

    //Levelups
    private bool leveledHp = false;
    private bool leveledStr = false;
    private bool leveledMag = false;
    private bool leveledSkl = false;
    private bool leveledSpd = false;
    private bool leveledDef = false;

    [SerializeField] Text lvHp;
    [SerializeField] Text lvStr;
    [SerializeField] Text lvMag;
    [SerializeField] Text lvSkl;
    [SerializeField] Text lvSpd;
    [SerializeField] Text lvDef;

    private AudioSource swing;


    // Start is called before the first frame update
    void Start()
    {
        currentTile.text = string.Empty;
        charName.text = string.Empty;
        tileDesc.text = string.Empty;
        swing = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Info and UI stuff
        currentChar = pointer.CurrentChar;
        if(currentChar.currentHp > currentChar.hp)
        {
            currentChar.currentHp = currentChar.hp;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            if (!charInfoShown)
            {
                charInfo.SetActive(true);
                charInfoShown = true;
            }
            else
            {
                charInfo.SetActive(false);
                charInfoShown = false;
            }
        }
        //Fadeout effect
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
            SceneManager.LoadScene("End");
        }
        //Char info screen text assignment compared to the current char that the pointer is selecting
        charSquareName.text = currentChar.name;
        charDesc.text = currentChar.description;
        charLikes.text = currentChar.likes;
        charDislikes.text = currentChar.dislikes;
        charClass.text = "Class: " + currentChar.charClass;
        charCurrHp.text = "HP: " + currentChar.currentHp.ToString();
        charMaxHp.text = currentChar.hp.ToString();
        charStr.text = "Str: " + currentChar.str.ToString();
        charMag.text = "Mag: " + currentChar.mag.ToString();
        charSkl.text = "Skl: " + currentChar.skl.ToString();
        charSpd.text = "Spd: " + currentChar.spd.ToString();
        charDef.text = "Def: " + currentChar.def.ToString();
        charMov.text = "Movement: " + currentChar.mov.ToString();
        charHit.text = "Hit: " + currentChar.UnitHit.ToString();
        charAtk.text = "Attack: " + currentChar.UnitAttack.ToString();
        charAvoid.text = "Avoid:" + currentChar.UnitAvoid.ToString();
        charEXP.text = "EXP: " + currentChar.exp.ToString();
        exp.text = charEXP.text;

        //Enable movement for all units again if all of them moved
        if(pat.wait && eve.wait && will.wait && ella.wait)
        {
            eve.wait = false;
            pat.wait = false;
            will.wait = false;
            fab.wait = false;
            ella.wait = false;
        }
        //Get rid of the pointer when the char info is on screen
        if (charInfoShown)
        {
            pointer.gameObject.SetActive(false);
        }
        else
        {
            pointer.gameObject.SetActive(true);
        }
        currentTile.text = pointer.CurrentTile;
        tileDesc.text = pointer.TileDesc;

        charName.text = currentChar.name;

        //Checks if any main menu is out
        if(waitOut || attackOut || charInfoShown || healOut)
        {
            menuOut = true;
        }
        else
        {
            menuOut = false;
        }
        //Movement of the pointer
        if (Input.GetKeyDown(KeyCode.UpArrow) && !menuOut)
        {
            pointer.transform.position = new Vector2 (pointer.transform.position.x, pointer.transform.position.y + 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !menuOut)
        {
            pointer.transform.position = new Vector2(pointer.transform.position.x, pointer.transform.position.y - 1);

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !menuOut)
        {
            pointer.transform.position = new Vector2(pointer.transform.position.x - 1, pointer.transform.position.y);

        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !menuOut)
        {
            pointer.transform.position = new Vector2(pointer.transform.position.x + 1 , pointer.transform.position.y);
        }
        //Actions if Z is pressed
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //If the selected character isn't in wait.
            if(currentChar != null && !currentChar.wait)
            {
                initialPos = pointer.transform.position;
                moving = true;
                
                currentChar.transform.position = pointer.transform.position;

                if (currentChar.Target == null) //if we are not on range of a target
                {
                    if (!waitOut)
                    {
                        waitMenu.SetActive(true);
                        waitOut = true;
                    }
                    else
                    {
                        waitMenu.SetActive(false);
                        waitOut = false;
                        moving = false;
                        currentChar.wait = true;
                    }
                }
                if(currentChar.Target != null && currentChar.Target.CompareTag("Enemy") && currentChar.charClass != "Counselor") //on range of an enemy
                {
                    if (!attackOut)
                    {
                        attackMenu.SetActive(true);
                        attackOut = true;
                        UpdateBattleForecast(currentChar, currentChar.Target);
                        forecast.SetActive(true);
                    }
                    else
                    {
                        attackMenu.SetActive(false);
                        attackOut = false;
                        forecast.SetActive(false);
                        moving = false;
                        Attack(currentChar, currentChar.Target);
                        pointer.gameObject.SetActive(true);
                    }
                } 
                if (currentChar.Target != null && currentChar.Target.CompareTag("Player") && currentChar.charClass == "Counselor" && currentChar.Target.currentHp < currentChar.Target.hp) //in range of an ally while being a Counselor
                {
                    if (!healOut)
                    {
                        healMenu.SetActive(true);
                        healOut = true;
                    }
                    else
                    {
                        healMenu.SetActive(false);
                        healOut = false;
                        moving = false;
                        Heal(currentChar, currentChar.Target);
                        pointer.gameObject.SetActive(true);
                    }
                }
            }
        } 
        //Actions if X is pressed
        else if (Input.GetKeyDown(KeyCode.X))
        {
            //Get rid of all the actions that can appear and return to moving
            if (waitOut)
            {
                waitMenu.SetActive(false);
                waitOut = false;
                moving = true;
                pointer.gameObject.SetActive(true);
            }
            else if (attackOut)
            {
                attackMenu.SetActive(false);
                attackOut = false;
                moving = true;
                pointer.gameObject.SetActive(true);
                forecast.SetActive(false);
            }
            else if (healOut)
            {
                healMenu.SetActive(false);
                healOut = false;
                moving = true;
                pointer.gameObject.SetActive(true);
            }
        }
        //Pressing space will hide the lv up and the exp panel when its out
        else if(Input.GetKeyDown(KeyCode.Space)) 
        {
            if (expPanel.activeSelf)
            {
                expPanel.SetActive(false);
            }
            if (levelPanel.activeSelf)
            {
                lvHp.enabled = false;
                lvStr.enabled = false;
                lvSkl.enabled = false;
                lvMag.enabled = false;
                lvSpd.enabled = false;
                lvDef.enabled = false;
                levelPanel.SetActive(false);
            }
        }
    }

    //Updates the battle forecast comparing the target with the unit attacking
    private void UpdateBattleForecast(Evelyn unit, Evelyn target)
    {
        int unitHit = unit.UnitHit - target.UnitAvoid;
        int targetHit = target.UnitHit - unit.UnitAvoid;
        int unitAtk = unit.UnitAttack - target.def;
        int targetAtk = target.UnitAttack - unit.def;

        fAlly.text = unit.name;
        fEnem.text = target.name;
        fAllyHp.text = unit.currentHp.ToString();
        fEnemHp.text = target.currentHp.ToString();
        fAllyDmg.text = unitAtk.ToString();
        fEnemDmg.text = targetAtk.ToString();
        if (unit.spd >= target.spd + 4)
            fAllyDouble.enabled = true;
        fAllyHit.text = unitHit.ToString();
        fEnemHit.text = targetHit.ToString();
        fAllyCrit.text = (unit.UnitCrit - target.UnitCritAvoid).ToString();  
        fEnemCrit.text = (target.UnitCrit - unit.UnitCritAvoid).ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fading = true;
        }
    }

    //Does the action of attacking. Compares the stats of both units to a random number between 0 and 100 to determine the attack.
    private void Attack(Evelyn unit, Evelyn target)
    {
        swing.Play();
        int unitHit = unit.UnitHit - target.UnitAvoid;
        int targetHit = target.UnitHit - unit.UnitAvoid;
        int unitAtk = unit.UnitAttack - target.def;
        int targetAtk = target.UnitAttack - unit.def;
        if (unit.range == 2)
        {
            if (unit.spd >= target.spd + 4)
            {
                if (target.CurrentTile == "Fort")
                    unitAtk--;
                if (GetRN() < unitHit)
                {
                    if(GetRN() < unit.UnitCrit - target.UnitCritAvoid)
                    {
                        target.currentHp -= unitAtk * 3;
                    }
                    else
                        target.currentHp -= unitAtk;
                }
                if (GetRN() < unitHit)
                {
                    if (GetRN() < unit.UnitCrit - target.UnitCritAvoid)
                    {
                        target.currentHp -= unitAtk * 3;
                    }
                    else
                        target.currentHp -= unitAtk;
                }
            }
            else
            {
                if (GetRN() < unitHit)
                {
                    if (GetRN() < unit.UnitCrit - target.UnitCritAvoid)
                    {
                        target.currentHp -= unitAtk * 3;
                    }
                    else
                        target.currentHp -= unitAtk;
                }
            }
        }
        else
        {
            if (unit.spd >= target.spd + 4)
            {
                if (GetRN() < unitHit)
                {
                    if (GetRN() < unit.UnitCrit - target.UnitCritAvoid)
                    {
                        target.currentHp -= unitAtk * 3;
                    }
                    else
                        target.currentHp -= unitAtk;
                }
                if (GetRN() < targetHit)
                {
                    if(GetRN() < target.UnitCrit - unit.UnitCritAvoid)
                        unit.currentHp -= targetAtk * 3;
                    else 
                        unit.currentHp -= targetAtk;
                }
                if (GetRN() < unitHit)
                {
                    if (GetRN() < unit.UnitCrit - target.UnitCritAvoid)
                    {
                        target.currentHp -= unitAtk * 3;
                    }
                    else
                        target.currentHp -= unitAtk;
                }
            }
            else
            {
                if (GetRN() < unitHit)
                {
                    if (GetRN() < unit.UnitCrit - target.UnitCritAvoid)
                    {
                        target.currentHp -= unitAtk * 3;
                    }
                    else
                        target.currentHp -= unitAtk;
                }
                if (GetRN() < target.UnitCrit - unit.UnitCritAvoid)
                    unit.currentHp -= targetAtk * 3;
                else
                    unit.currentHp -= targetAtk;
            }
        }

        GiveExp(unit);
    }

    //Gives experience and shows the levelup if there has been one.
    private void GiveExp(Evelyn unit)
    {
        unit.exp += 30;
        unit.wait = true;
        
        if (unit.exp >= 100)
        {
            unit.exp = 0;
            unit.LevelUp(out leveledHp, out leveledStr, out leveledMag, out leveledSkl, out leveledSpd, out leveledDef);
            levelPanel.SetActive(true);
            if (leveledHp)
                lvHp.enabled = true;
            if (leveledStr)
                lvStr.enabled = true;
            if (leveledMag)
                lvMag.enabled = true;
            if (leveledSkl)
                lvSkl.enabled = true;
            if (leveledSpd)
                lvSpd.enabled = true;
            if (leveledDef)
                lvDef.enabled = true;
        }
        else
        {
            expPanel.SetActive(true);
        }
    }

    //Performs the action of healing.
    private void Heal(Evelyn unit, Evelyn target)
    {
        int unitHeal = unit.mag + 10;
        target.currentHp += unitHeal;
        unit.wait = true;
        GiveExp(unit);
    }

    //Draws a random number between 0 and 100
    private int GetRN()
    {
        return Random.Range(0, 101);
    }
    //Unused
    private IEnumerator WaitABit()
    {
        yield return new WaitForSeconds(2f);
    }
}
