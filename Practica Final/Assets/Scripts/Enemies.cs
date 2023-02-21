using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    private NavMeshAgent navMeshAgent;
    [SerializeField] GameObject objective;
    private bool aggro = false;
    private Vector3 siguientePosicion;
    private byte numeroSiguientePosicion;
    private float distanciaCambio = 1f;
    private float velocidad = 2;
    public int hp = 3;

    void Start()
    {
        siguientePosicion = wayPoints[0].position;
        numeroSiguientePosicion = 0;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (!aggro) 
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
        else
        {
            navMeshAgent.SetDestination(objective.transform.position);
        }
        double inbetweenX = objective.transform.position.x - gameObject.transform.position.x;
        double inbetweenY = objective.transform.position.y - gameObject.transform.position.y;
        if (Math.Abs(inbetweenX) <= 20 && Math.Abs(inbetweenY) <= 10)
        {
            aggro = true;
        }
    }
    public void HurtZombie()
    {
        if(hp > 0)
        {
            hp--;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
