using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {
    public bool gameOver = false;
    public static GameController instance;//singleton
    public Text gameOverText;
    public Text ScoreText;
    private int score = 0;
    public float scrollSpeed = -2f;
    // Use this for initialization
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

        ScoreText.text = "Score :" +score.ToString();
        gameOverText.text = "";

    }
    // Update is called once per frame
    void Update () {
        EscapeGame();
        RestartGame();
	}

    //MEthoden-------------------------------------------------------------------------------------------------------
    private void EscapeGame()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
        Application.Quit();
        }
    }

    private void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.R))

        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    //public Methoden
    public void GameOver()
    {
        gameOverText.text = "Doge ded\n pres r to restart or esc to exit";
        gameOver = true;

    }
    public void IncrementScore()
    {
        score++;
        ScoreText.text = "Score: "+ score.ToString();

    }



}
