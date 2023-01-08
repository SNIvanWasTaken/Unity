using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoversePlayer : MonoBehaviour
{
    [SerializeField] float velocidad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * velocidad * Time.deltaTime, vertical * velocidad * Time.deltaTime, 0);
        if (transform.position.y < -2.2)
        {
            transform.Translate(0, 0.1f, 0);
        }
        else if (transform.position.y > 2.2)
        {
            transform.Translate(0, -0.1f, 0);
        }
        if (transform.position.x >= 3.2)
            transform.Translate(-0.1f, 0, 0);

        if (transform.position.x <= -3.2)
            transform.Translate(0.1f, 0, 0);

        if (!Puntos.instancia.isAlive)
            Destroy(gameObject);
        
        if (Puntos.instancia.numeroNaves <= 0)
            Destroy(gameObject);
    }
}
