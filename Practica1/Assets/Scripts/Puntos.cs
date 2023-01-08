using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Puntos : MonoBehaviour
{
    [SerializeField] Text numNaves;
    [SerializeField] Text puntos;
    [SerializeField] Text ganar;
    [SerializeField] Text perder;
    public int numeroNaves = 5;
    public int numeroPuntos = 0;
    public bool isAlive = true;
    public static Puntos instancia;

    // Start is called before the first frame update
    void Start()
    {
        instancia = this;
        ganar.enabled = false;
        perder.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        numNaves.text = "Naves restantes: " + numeroNaves;
        puntos.text = "Puntos: " + numeroPuntos;
        if(numeroNaves == 0)
            ganar.enabled = true;

        if (!isAlive)
            perder.enabled = true;
    }
}
