using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickups : MonoBehaviour
{
    //Este script hace todo lo que tiene que ver con pickups
    public int Counter { get => counter; set => counter = value; }
    public int HealCounter { get => healCounter; set => healCounter = value; }

    [SerializeField] Text path;
    [SerializeField] Transform prefabParticula;
    private int counter;
    private float appear = 2f;
    private float disappear;
    private int healCounter;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        HealCounter = 0;
        path.enabled = false;
    }

    // Al pasar 2 segundos, el texto desaparece
    void Update()
    {
        if (path.enabled && Time.time >= disappear)
        {
            path.enabled = false;
        }
        if (healCounter >= 2)
        {
            Debug.Log("Lo conseguiste");
            FindObjectOfType<GameManager>().HealPlayer();
            healCounter = 0;
        }

    }

    //Al colisionar con el jugador, se emitirán partículas, destruiran el pickup y incrementa el contador
    //Además, si el contador ha llegado a 10, saldrá un texto y se abrirá un portal.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(prefabParticula, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
            counter++;
            healCounter += 1;
            disappear = Time.time + appear;
        }
    }
}
