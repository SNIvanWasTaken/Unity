using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text soulsText;
    private int souls;
    [SerializeField] Text gameOver;
    [SerializeField] AudioClip gameOverSFX;
    // Start is called before the first frame update
    void Start()
    {
        souls = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HurtPlayer()
    {
        souls--;
        soulsText.text = "You have " + souls + " souls remaining";
        FindObjectOfType<MovePlayer>().Respawn();
        if (souls <= 0)
        {
            gameOver.text = "Game over";
            AudioSource.PlayClipAtPoint(gameOverSFX, transform.position);
            StartCoroutine(BackToTitleScreen());
        }

    }

    public void HealPlayer()
    {
        souls++;
        soulsText.text = "You have " + souls + " souls remaining";
    }

    private IEnumerator BackToTitleScreen()
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.65f);
        Time.timeScale = 1;
        SceneManager.LoadScene("1.Intro");
    }
}
