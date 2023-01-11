using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionBalaEnemiga : MonoBehaviour
{
    [SerializeField] Transform prefabExplosion;
    public AudioClip audioExplosion;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Transform explosion = Instantiate(prefabExplosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(audioExplosion, gameObject.transform.position);
            Destroy(explosion.gameObject, 2f);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            GetComponent<AudioSource>().Play();
            Puntos.instancia.isAlive = false;
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
