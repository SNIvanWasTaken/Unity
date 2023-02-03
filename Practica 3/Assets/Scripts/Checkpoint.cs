using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    //Este script ense�a un texto de checkpoint y cambiar� el spawn.

    [SerializeField] AudioSource bonfireSFX;
    private bool alreadyPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        bonfireSFX = GetComponent<AudioSource>();
        
    }

    // Al pasar 2 segundos, el texto desaparece
    void Update()
    {

    }

    //Al colisionar con una hoguera o c�rculo de luz, mostrar� el texto y cambiar� el spawn.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !alreadyPlayed)
        {
            FindObjectOfType<GameManager>().BonfireLit(alreadyPlayed);
            bonfireSFX.Play();
            FindObjectOfType<MovePlayer>().PosX = transform.position.x;
            FindObjectOfType<MovePlayer>().PosY = transform.position.y;
            alreadyPlayed = true;
        }
    }
}
