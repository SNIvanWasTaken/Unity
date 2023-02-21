using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickups : MonoBehaviour
{
    //Este script hace todo lo que tiene que ver con pickup

    [SerializeField] Transform prefabParticula;
   
    private float appear = 2f;
    private float disappear;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Al pasar 2 segundos, el texto desaparece
    void Update()
    {
            
    }

    //Al colisionar con el jugador, se emitirán partículas, destruiran el pickup y incrementa el contador
    //Además, si el contador ha llegado a 10, saldrá un texto y se abrirá un portal.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(prefabParticula, collision.transform.position, Quaternion.identity);
            FindObjectOfType<GameManager>().addPickup();   
            disappear = Time.time + appear;
            Destroy(gameObject);
        }
    }
}
