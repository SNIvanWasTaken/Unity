using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    //Este script ense�a un texto de checkpoint y cambiar� el spawn.

    [SerializeField] Text lit;
    [SerializeField] Text key;
    private float appear = 2f;
    private float disappear;
    // Start is called before the first frame update
    void Start()
    {
        lit.enabled = false;
        key.enabled = false;
    }

    // Al pasar 2 segundos, el texto desaparece
    void Update()
    {
        if (lit.enabled && Time.time >= disappear)
        {
            lit.enabled = false;
        }
        if (key.enabled && Time.time >= disappear)
        {
            key.enabled = false;
        }
    }

    //Al colisionar con una hoguera o c�rculo de luz, mostrar� el texto y cambiar� el spawn.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.CompareTag("Bonfire") && collision.CompareTag("Player"))
        {
            lit.enabled = true;
            disappear = Time.time + appear;
            
            //Set checkpoint
        }
        else if(gameObject.CompareTag("Light Circle") && collision.CompareTag("Player"))
        {
            key.enabled = true;
            disappear = Time.time + appear;
            //Set checkpoint
        }
    }
}
