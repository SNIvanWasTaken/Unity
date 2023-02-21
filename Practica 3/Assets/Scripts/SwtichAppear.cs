using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwtichAppear : MonoBehaviour
{
    public bool Swap { get => swap; set => swap = value; }

    private BoxCollider2D bc;
    private SpriteRenderer sr;
    private bool swap;
    private float appear = 0.33f;
    private float disappear;


    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        swap = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (swap && Time.time >= disappear)
        {
            Switch();
        }
        if (!swap)
        {
            bc.enabled = true;
            sr.enabled = true;
        }
    }

    private void Switch()
    {
        if (bc.enabled)
        {
            bc.enabled = false;
        }
        else
        {
            bc.enabled = true;
        }
        if (sr.enabled)
        {
            sr.enabled = false;
        }
        else
        {
            sr.enabled = true;
        }
        disappear = Time.time + appear;
    }
}
