using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasserTod : MonoBehaviour {

    private Player player;
    private GameController gameController;
	// Use this for initialization
	void Start () {

        GameObject PlayerObject = GameObject.FindWithTag("Player");
        if (PlayerObject != null)
        {
            player = PlayerObject.GetComponent<Player>();
        }
        if (player == null)
        {
            Debug.Log("Who?");
        }

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Who?");
        }
    }
	
	// Update is called once per frame
	void Update () {
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.isDead = true;
        gameController.gameover = true;
     
    }
}
