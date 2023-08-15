using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string name = "";
    public int hit = 0;
    public int might = 0;
    public int crit = 0;

    public Weapon(string name, int hit, int might, int crit)
    {
        this.name = name;
        this.hit = hit;
        this.might = might;
        this.crit = crit;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
