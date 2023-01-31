using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerArea : MonoBehaviour
{
    //Este script enseña el nombre del area.

    [SerializeField] Text area;
    private float appear = 2f;
    private float disappear;
    private bool hasEntered = false;

    // Start is called before the first frame update
    void Start()
    {
        area.enabled = false;
    }

    // Al pasar 2 segundos, el texto desaparece
    void Update()
    {
        if(area.enabled && Time.time >= disappear)
        {
            area.enabled = false;
            hasEntered = true;
        }
    }

    //Al colisionar con algo invisible al principio, mostrará el texto.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && hasEntered == false)
        {
            area.enabled = true;
            disappear = Time.time + appear;
        }
    }
}
