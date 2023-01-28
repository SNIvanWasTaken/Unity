using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerController>().Restore();
            FindObjectOfType<WallDisappear>().Restore();
            Rotator[] pickups = FindObjectsOfType<Rotator>();
            foreach(Rotator r in pickups)
            {
                r.Restore();
            }
        }
    }
}
