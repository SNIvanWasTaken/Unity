using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float speed;
    int nextStep = 0;
    Vector2 nextWaypoint;
    bool goingForward = true;
    float swap = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        nextWaypoint = waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, nextWaypoint, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, nextWaypoint) < swap)
        {
            if (goingForward)
            {
                nextStep++;
                Vector2 waypoint = nextWaypoint - (Vector2)transform.position;
            }
            else
            {
                nextStep--;
                Vector2 waypoint = nextWaypoint - (Vector2)transform.position;
            }
            if (nextStep >= waypoints.Length)
            {
                goingForward = false;
                nextStep = waypoints.Length - 1;
            }
            if (nextStep == 0)
            {
                goingForward = true;
            }
            nextWaypoint = waypoints[nextStep].position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().HurtPlayer();
            GetComponent<AudioSource>().Play();
        }
    }
}
