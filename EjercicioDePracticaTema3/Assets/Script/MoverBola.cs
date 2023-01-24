 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBola : MonoBehaviour
{
    private Rigidbody body;
    float velocidadAvance = 100.0f;
    float velocidadAvanceZ = 100.0f;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");
        Vector3 movimiento = new Vector3(x, 0.0f, -z);
        body.AddForce(movimiento * velocidadAvance);
    }
}
