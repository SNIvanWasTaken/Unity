using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRangeArcher : MonoBehaviour
{
    //Tile triggers for archers
    public bool OnRange { get => onRange; set => onRange = value; }
    public Evelyn Enemy { get => enemy; set => enemy = value; }


    private Evelyn enemy;

    private bool onRange = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy = collision.gameObject.GetComponent<Evelyn>();
            onRange = true;
        }
    }
}
