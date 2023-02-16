using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    Vector3 siguientePosicion;
    byte numeroSiguientePosicion;
    float distanciaCambio = 0.2f;
    float velocidad = 2;
    void Start()
    {
        siguientePosicion = wayPoints[0].position;
        numeroSiguientePosicion = 0;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,
        siguientePosicion,
       velocidad * Time.deltaTime);
        if (Vector3.Distance(transform.position, siguientePosicion) <
        distanciaCambio)
        {
            numeroSiguientePosicion++;
            if (numeroSiguientePosicion >= wayPoints.Length)
                numeroSiguientePosicion = 0;
            siguientePosicion = wayPoints[numeroSiguientePosicion].position;
            transform.LookAt(siguientePosicion);
        }
    }
}
