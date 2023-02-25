using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    //Este script es el del enemigo.

    [SerializeField] Transform[] wayPoints;
    private NavMeshAgent navMeshAgent;
    [SerializeField] GameObject objective;
    [SerializeField] float speed;
    private bool aggro = false;
    private Vector3 siguientePosicion;
    private byte numeroSiguientePosicion;
    private float distanciaCambio = 2f;
    public int hp = 2;
    private Animator animator;
    private float disappear;
    private float disappear2;
    private float appear = 1f;
    private bool isDying = false;

    //Al empezar pillamos sus componentes necesarios y asignamos los waypoints.
    void Start()
    {
        siguientePosicion = wayPoints[0].position;
        numeroSiguientePosicion = 0;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    //Cuando el zombi este a sus anchas se moverá entre los checkpoint.
    void Update()
    {
        if (!aggro) 
        {
            navMeshAgent.SetDestination(siguientePosicion);
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
            //Pero cuando el zombi esté cerca del jugador irá hacia él y correrá
            navMeshAgent.SetDestination(objective.transform.position);
            navMeshAgent.speed = 3f;
        }
        double inbetweenX = objective.transform.position.x - gameObject.transform.position.x;
        double inbetweenY = objective.transform.position.y - gameObject.transform.position.y;
        if (Math.Abs(inbetweenX) <= 10 && Math.Abs(inbetweenY) <= 10)
        {
            aggro = true;
            animator.SetBool("Walk", false);
            animator.SetBool("Aggro", true);
        }
        if(Time.time >= disappear && !animator.GetBool("Aggro") && animator.GetBool("Close"))
        {
            animator.SetBool("Aggro", true);
            animator.SetBool("Close", false);
        }
        if(isDying && Time.time >= disappear2)
        {
            Destroy(gameObject);
        }
        //Al ser disparado varias veces, hará una animacion de morirse y se destruirá
    }

    //Esta función hace daño al zombi o lo mata.
    public void HurtZombie()
    {
        if(hp > 0)
        {
            hp--;
        }
        else
        {
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            navMeshAgent.speed = 0f;
            FindObjectOfType<GameManager>().zombies--;
            Debug.Log(FindObjectOfType<GameManager>().zombies);
            animator.SetBool("Walk", false);
            animator.SetBool("Aggro", false);
            animator.SetBool("Close", false);
            animator.SetBool("Die", true);
            isDying = true;
            disappear2 = Time.time + 2f;
        }
    }
    //Esta funcion hace daño al jugador cuando colisiona con el
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            animator.SetBool("Close", true);
            animator.SetBool("Aggro", false);
            disappear = Time.time + appear;
            FindObjectOfType<GameManager>().HurtPlayer();
        }
    }
}
