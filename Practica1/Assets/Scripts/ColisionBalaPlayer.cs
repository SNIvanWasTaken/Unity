using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ColisionBalaPlayer : MonoBehaviour
{
    [SerializeField] Transform prefabExplosion;
    private int numeroNaves = 5;
    private int numeroPuntos = 0;
    public AudioClip audioExplosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemigo")
        {
            Transform explosion = Instantiate(prefabExplosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(audioExplosion, gameObject.transform.position);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Destroy(explosion.gameObject, 2f);
            Puntos.instancia.numeroPuntos += 1000;
            Puntos.instancia.numeroNaves--;
        }
    }
    private void Update()
    {
        if (!Puntos.instancia.isAlive)
            Destroy(gameObject);
        if (Puntos.instancia.numeroNaves <= 0)
            Destroy(gameObject);
    }
}
