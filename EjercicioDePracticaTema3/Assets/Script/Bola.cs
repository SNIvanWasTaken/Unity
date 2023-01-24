using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    private Rigidbody body;
    float velocidad = 200f;
    // Start is called before the first frame update
    void Start()
    {
        // Recogemos el Rigidbody del objeto
        body = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        float avance = Input.GetAxis("Vertical") * velocidad
        * Time.deltaTime;
        float lado = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        body.velocity = new Vector3(avance, 0, lado);
    }
}
