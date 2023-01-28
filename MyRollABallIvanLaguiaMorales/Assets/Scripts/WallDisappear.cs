using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDisappear : MonoBehaviour
{
    MeshRenderer mr;
    BoxCollider bc;
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        bc = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mr.enabled = false;
            bc.enabled = false;
        }
    }
    public void Restore()
    {
        mr.enabled = true;
        bc.enabled = true;
    }
}
