using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Camera camara;
    private AudioSource shot;
    // Start is called before the first frame update
    void Start()
    {
        shot = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shot.Play();
            float distanciaMaxima = 10;
            RaycastHit hit;
            bool impactado = Physics.Raycast(camara.transform.position,
            camara.transform.forward, out hit, distanciaMaxima);
            if (impactado)
            {
                if (hit.collider.CompareTag("Enemigo"))
                {
                    hit.collider.gameObject.GetComponent<Enemies>().HurtZombie();                }
            }
        }
    }
}
