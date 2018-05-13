using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public GameObject enemy;

    public float modoluNumber = 60;

    public Text gameOverText;
    public bool isgameOver;


    public Text scoreText;
    public int score;

    public Text resetText;
    private bool reset;


    public Vector3 spawnStuff;

    void Start()
    {
        gameOverText.text = "";
        resetText.text = "";
        isgameOver = false;
        reset = false;
        score = 0;
        UpdateScore();
   
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
        if (reset)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }


    }
    void SpawnEnemy()
    {
        
        if (Time.frameCount % modoluNumber == 0 && isgameOver == false)
        {

            spawnStuff.x = Random.Range(-5f , 5f);
            spawnStuff.y = 9f;
            spawnStuff.z = 0;
            Instantiate(enemy, spawnStuff, Quaternion.identity);

        }


        if (isgameOver)
        {
            resetText.text = "Press R to restart";
            reset = true;
    

        }
    }



    public void IncrementScore(int plusScoreValue)
    {
        score += plusScoreValue;
        UpdateScore();
        if(score%200 == 0)
        {
            modoluNumber = modoluNumber/2;
        }
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }



    public void GameOver()

    {

        gameOverText.text += "Nothing personnel kid";
        isgameOver = true;
    }



}




