using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerTrigger : MonoBehaviour
{
    //Information for the pointer
    public string CurrentTile { get => currentTile; set => currentTile = value; }
    public string TileDesc { get => tileDesc; set => tileDesc = value; }
    public Evelyn CurrentChar { get => currentChar; set => currentChar = value; }

    private string currentTile = string.Empty;
    private string tileDesc = string.Empty;

    private Evelyn currentChar;

    private bool onFort = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!onFort)
        {
            CurrentTile = "Sand";
            tileDesc = "";
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fort"))
        {
            onFort = true;
            currentTile = "Forts provide:";
            tileDesc = "+1 def";
        }

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            currentChar = collision.gameObject.GetComponent<Evelyn>();
        }
        if (collision == null)
        {
            currentChar = null;
            onFort = false;
        }
    }
}
