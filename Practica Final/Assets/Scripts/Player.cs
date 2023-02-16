using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Camera camara;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Disparando...");
            float distanciaMaxima = 50;
            RaycastHit hit;
            bool impactado = Physics.Raycast(camara.transform.position,
            camara.transform.forward, out hit, distanciaMaxima);
            if (impactado)
            {
                Debug.Log("Disparo impactado");
                if (hit.collider.CompareTag("Enemigo"))
                {
                    Debug.Log("Enemigo acertado");
                }
            }
        }
    }
}
