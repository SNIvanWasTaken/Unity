using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] float velocidad = 7f;
    [SerializeField] float velocidadSalto = 1f;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    private bool playing = false;
    private float play = 0.44f;
    private float stop;
    private float alturaPersonaje;  

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        alturaPersonaje = GetComponent<Collider2D>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Salto

        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
        float salto = Input.GetAxis("Jump");

        if (salto > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0, -1));
            if (hit.collider != null)
            {
                float distanciaAlSuelo = hit.distance;
                bool tocandoElSuelo = distanciaAlSuelo < alturaPersonaje;
                if (tocandoElSuelo)
                {
                    Vector3 fuerzaSalto = new Vector3(0, velocidadSalto, 0);
                    rb.AddForce(fuerzaSalto, ForceMode2D.Impulse);
                }
            }           
        }

        //Animaciones

        if(Time.time >= stop)
        {
            playing = false;
        }
        if (horizontal > 0.1f && !playing)
        {
            sr.flipX = false;
            animator.Play("NerdRunning");
            playing = true;
            stop = Time.time + play;
        }
        else if (horizontal < -0.1f && !playing)
        {
            sr.flipX = true;
            animator.Play("NerdRunning");
            playing = true;
            stop = Time.time + play;
        }
        if (rb.velocity.y > 0)
        {
            animator.Play("Jump");
        }
        else if (rb.velocity.y < 0) 
        {
            animator.Play("Falling");
        }
    }
}
