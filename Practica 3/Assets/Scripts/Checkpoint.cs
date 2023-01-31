using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] Text lit;
    [SerializeField] Text key;
    private float appear = 2f;
    private float disappear = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lit.enabled && Time.time >= disappear)
        {
            lit.enabled = false;
        }
        if (key.enabled && Time.time >= disappear)
        {
            key.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.CompareTag("Bonfire") && collision.CompareTag("Player"))
        {
            lit.enabled = true;
            disappear = Time.time + appear;
            
            //Set checkpoint
        }
        else if(gameObject.CompareTag("Light Circle") && collision.CompareTag("Player"))
        {
            key.enabled = true;
            disappear = Time.time + appear;
            //Set checkpoint
        }
    }
}
