using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

    public bool gameover = false; // Water Sets GameOver True
    public bool bananaEaten = false;// Banana Sets Eaten True and wasserSpiegel hört auf zu steigen

    public Text gameOverText;
    public Text winningText;
    public Text startingText;
    private bool fiveSecondsPassed = false;
    void Start () {
        gameOverText.text = "";
        winningText.text = "";
        startingText.text = "Find the holy treasure or the water will kill you";
        
        
    
	}
	
	// Update is called once per frame
	void Update ()
    {
        ExitGame();
        GameStartedforText();
        GameOver();
        Winning();
    }


    // Methods
    // ---------------------------------------------------------------------------------
   private void ExitGame()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
   
   private void Winning()
    {
        if (bananaEaten)
        {
            winningText.text = "HUHA\nTranslation:\nYou ate the Banana of Destiny and saved many monkey people you win\nYou can play again if you want Press R/or Leave ESC";
            ResetGame();
        }
    }
    private void GameOver()
    {
        if (gameover)
        {
            gameOverText.text = "HAHUHA\nNothun personnel kid \nThe Game will restart soon \n Press R to play again/or Leave ESC ";
            ResetGame();
            if(Time.frameCount%1200 == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private void GameStartedforText()
    {

        if (!fiveSecondsPassed)
        {
            if (Time.frameCount%300==0)
             {
            startingText.text = "";
            fiveSecondsPassed = true;
             }

        }
    }
    //Methoden in Methoden
   //----------------------------------------------------------------------------------------
    private void ResetGame()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
