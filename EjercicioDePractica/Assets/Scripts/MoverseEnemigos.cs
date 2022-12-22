using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverseEnemigos : MonoBehaviour
{
    [SerializeField] float velocidadX = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidadX * Time.deltaTime, 0, 0);
        if (transform.position.x < -3)
        {
            if (transform.position.y <= -3)
                Destroy(this);
            else
            {
                velocidadX = -velocidadX;
                transform.Translate(0.1f, -0.5f, 0);
            }
        }
        else if (transform.position.x > 3)
        {
            if (transform.position.y <= -3)
                Destroy(this);
            else
            {
                velocidadX = -velocidadX;
                transform.Translate(-0.1f, -0.5f, 0);
            }
        }
    }
}
