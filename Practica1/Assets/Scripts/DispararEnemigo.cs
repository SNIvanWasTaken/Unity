using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararEnemigo : MonoBehaviour
{
    [SerializeField] Transform prefabBala;
    [SerializeField] float velocidadBala;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disparar());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Disparar()
    {
        float pausa = Random.Range(4f, 8f);
        yield return new WaitForSeconds(pausa);
        Transform disparo = Instantiate(prefabBala, transform.position, Quaternion.identity);
        disparo.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(velocidadBala, 0, 0);
        Destroy(disparo.gameObject, 8f);
        StartCoroutine(Disparar());
    }
}
