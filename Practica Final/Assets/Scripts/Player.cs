using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Este script da funcionalidad al jugador

    [SerializeField] Camera camara;
    private AudioSource shot;
    // Start is called before the first frame update
    void Start()
    {
        //Recogemos el audio del disparo al empezar.
        shot = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        //Cuando se haga click al M1, Se reducirá la municion y se disparará
        if (Input.GetButtonDown("Fire1"))
        {
            FindObjectOfType<GameManager>().DecreaseAmmo();
            if (FindObjectOfType<GameManager>().gs.ammo > 0)
            {
                //Sonará el disparo y si impacta, le quitará vida al zombi
                shot.Play();
                float distanciaMaxima = 20;
                RaycastHit hit;
                bool impactado = Physics.Raycast(camara.transform.position,
                camara.transform.forward, out hit, distanciaMaxima);
                if (impactado)
                {
                    if (hit.collider.CompareTag("Enemigo"))
                    {
                        hit.collider.gameObject.GetComponent<Enemies>().HurtZombie();
                    }
                }

            }
        }
    }
}
