using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararPlayer : MonoBehaviour
{
    [SerializeField] Transform prefabBala;
    [SerializeField] float velocidad;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform disparo = Instantiate(prefabBala, transform.position, Quaternion.identity);
            disparo.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-velocidad, 0, 0);
            GetComponent<AudioSource>().Play();
            Destroy(disparo.gameObject, 8f);
        }
    }
}
