using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    //Este script enseña un texto de checkpoint y cambiará el spawn.

    [SerializeField] Text lit;
    [SerializeField] AudioSource bonfireSFX;
    private float appear = 2f;
    private float disappear;
    private bool alreadyPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        lit.enabled = false;
        bonfireSFX = GetComponent<AudioSource>();

    }

    // Al pasar 2 segundos, el texto desaparece
    void Update()
    {
        if (lit.enabled && Time.time >= disappear)
        {
            lit.enabled = false;
        }
    }

    //Al colisionar con una hoguera o círculo de luz, mostrará el texto y cambiará el spawn.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && alreadyPlayed == false)
        {
            lit.enabled = true;
            bonfireSFX.Play();
            alreadyPlayed = true;
            disappear = Time.time + appear;
            FindObjectOfType<MovePlayer>().PosX = transform.position.x;
            FindObjectOfType<MovePlayer>().PosY = transform.position.y;
        }
    }
}
