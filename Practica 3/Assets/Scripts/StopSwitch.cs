using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SwtichAppear[] pickups = FindObjectsOfType<SwtichAppear>();
            foreach(SwtichAppear s in pickups)
            {
                s.Swap = false;
            }
        }
    }
}
