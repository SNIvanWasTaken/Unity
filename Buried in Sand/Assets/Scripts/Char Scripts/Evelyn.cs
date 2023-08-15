using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Evelyn : MonoBehaviour
{
    //Stat properties

    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }
    public int CurrentHp
    {
        get { return currentHp; }
        set { currentHp = value; }
    }

    public int Str
    {
        get { return str; }
        set { str = value; }
    }

    public int Mag
    {
        get { return mag; }
        set { mag = value; }
    }

    public int Skl
    {
        get { return skl; }
        set { skl = value; }
    }

    public int Spd
    {
        get { return spd; }
        set { spd = value; }
    }

    public int Def
    {
        get { return def; }
        set { def = value; }
    }

    public int Mov
    {
        get { return mov; }
        set { mov = value; }
    }

    //Growth properties
    public global::System.Int32 GHp { get => gHp; set => gHp = value; }
    public global::System.Int32 GStr { get => gStr; set => gStr = value; }
    public global::System.Int32 GMag { get => gMag; set => gMag = value; }
    public global::System.Int32 GSkl { get => gSkl; set => gSkl = value; }
    public global::System.Int32 GSpd { get => gSpd; set => gSpd = value; }
    public global::System.Int32 GDef { get => gDef; set => gDef = value; }
    public int UnitHit { get => unitHit; set => unitHit = value; }
    public int UnitAvoid { get => unitAvoid; set => unitAvoid = value; }
    public int UnitAttack { get => unitAttack; set => unitAttack = value; }
    public int UnitCrit { get => unitCrit; set => unitCrit = value; }
    public int UnitCritAvoid { get => unitCritAvoid; set => unitCritAvoid = value; }
    public string CurrentTile { get => currentTile; set => currentTile = value; }
    public string TileDesc { get => tileDesc; set => tileDesc = value; }
    public Evelyn Target { get => target; set => target = value; }

    public int exp = 0;
    public List<Weapon> inventory = new List<Weapon>();
    
    private Weapon currentWeapon = null;
    
    //Triggers
    [SerializeField] List<OnRangeCheck> triggers = new List<OnRangeCheck>();
    [SerializeField] List<OnRangeArcher> archerTriggers= new List<OnRangeArcher>();
    private Evelyn target;

    //Info
    public string name = "Evelyn";
    public string description = "Calm and sassy lady with big aspirations";
    public string likes = "Likes: Selling";
    public string dislikes = "Dislikes: Sharpening her weapons";
    public string charClass = "Captain";

    //Bases
    public int hp = 28;
    public int currentHp = 28;
    public int str = 8;
    public int mag = 0;
    public int skl = 14;
    public int spd = 10;
    public int def = 4;
    public int mov = 6;
    public int range = 1;

    //Growths
    public int gHp = 65;
    public int gStr = 45;
    public int gMag = 0;
    public int gSkl = 80;
    public int gSpd = 65;
    public int gDef = 35;

    //Combat stats
    private int unitHit;
    private int unitAvoid;
    private int unitAttack;
    private int unitCrit;
    private int unitCritAvoid;
    private string currentTile = "Sand";
    private string tileDesc = "";

    public bool wait = false;

    // Start is called before the first frame update
    void Start()
    {
        unitAttack = str + 2;
        unitHit = skl * 20 + spd * 20 + 85;
        unitAvoid = spd * 20 + spd * 20;
        unitCrit = skl / 2 + 5;
        unitCritAvoid = skl / 2;
    }

    // Update is called once per frame
    void Update()
    {
        unitAttack = str + 2;
        unitHit = skl * 2 + spd * 2 + 85;
        unitAvoid = spd * 2 + spd * 2;
        unitCrit = skl / 2 + 5;
        unitCritAvoid = skl / 2;

        //If a unit is waiting they will have no animation
        if (wait)
        {
            GetComponent<Animator>().speed = 0;
        }
        else
        {
            GetComponent<Animator>().speed = 1;
        }
        //If a unit has 0 current hp they will die
        if(currentHp <= 0)
        {
            Destroy(gameObject);
        }

        //Assigns the target if any of the triggers have someone on range
        foreach(OnRangeCheck c in triggers)
        {
            if (c.OnRange)
            {
                target = c.Enemy;
            }
        }
        foreach(OnRangeArcher a in archerTriggers)
        {
            if (a.OnRange)
            {
                target = a.Enemy;
            }
        }
    }

    //Levels up and checks stats that have leveled
    public void LevelUp(out bool leveledHp, out bool leveledStr, out bool leveledMag, out bool leveledSkl, out bool leveledSpd, out bool leveledDef)
    {
        int rng = GetRN();
        leveledHp = false;
        leveledStr = false;
        leveledMag = false;
        leveledSkl = false;
        leveledSpd = false;
        leveledDef = false;

        if(rng < gHp)
        {
            hp++;
            leveledHp = true;
        }
        rng = GetRN();
        if (rng < gStr)
        {
            str++;
            leveledStr = true;
        }
        rng = GetRN();
        if (rng < gMag)
        {
            mag++;
            leveledMag = true;  
        }
        rng = GetRN();
        if (rng < gSkl)
        {
            skl++;
            leveledSkl = true;
        }
        rng = GetRN();
        if (rng < gSpd)
        {
            spd++;
            leveledSpd = true;
        }
        rng = GetRN();
        if (rng < gDef)
        {
            def++;
            leveledDef = true;
        }
    }
    //Generates random number
    private int GetRN()
    {
        return Random.Range(0, 101);
    }

    //Changes the tile info permanently once hovered by a fort
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fort"))
        {
            currentTile = "Fort";
            tileDesc = "+1 def";
        }
        else
        {
            currentTile = "Sand";
            tileDesc = "";
        }
    }
}
