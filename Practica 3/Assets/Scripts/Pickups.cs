using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickups : MonoBehaviour
{
    //Este script hace todo lo que tiene que ver con pickups
    [SerializeField] Text path;
    [SerializeField] Transform prefabParticula;
    [SerializeField] Transform portal;
    private BoxCollider2D col;
    private SpriteRenderer s;
    private int counter;
    private float appear = 2f;
    private float disappear;
    private int healCounter;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        healCounter = 0;
        col = portal.gameObject.GetComponent<BoxCollider2D>();
        s = portal.gameObject.GetComponent<SpriteRenderer>();
        col.enabled = false;
        s.enabled = false;
        path.enabled = false;
    }

    // Al pasar 2 segundos, el texto desaparece
    void Update()
    {
        if (path.enabled && Time.time >= disappear)
        {
            path.enabled = false;
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
            healCounter++;
            disappear = Time.time + appear;
            if (healCounter >= 5)
            {
                FindObjectOfType<GameManager>().HealPlayer();
                healCounter = 0;
            }
        }
        if (counter >= 1)
        {
            path.enabled = true;
            col.enabled = true;
            s.enabled = true;
        }
        if(counter >= 10)
        {

        }
    }
}
