using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverseEnemigos : MonoBehaviour
{
    [SerializeField] float velocidadY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, velocidadY * Time.deltaTime, 0);
        if (transform.position.y < -2.2)
        {
            if (transform.position.x >= 3.5)
                Destroy(this);
            else
            {
                velocidadY = -velocidadY;
                transform.Translate(0.5f, 0.2f, 0);
            }
        }
        else if (transform.position.y > 2.2)
        {
            if (transform.position.x >= 3.5)
                Destroy(this);
            else
            {
                velocidadY = -velocidadY;
                transform.Translate(0.5f, -0.2f, 0);
            }
        }
        if (!Puntos.instancia.isAlive)
            Destroy(gameObject);
        if (Puntos.instancia.numeroNaves <= 0)
            Destroy(gameObject);
    }
}
