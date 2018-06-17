using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasserSpiegel : MonoBehaviour {

    // Use this for initialization
    GameController gameController;
	void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("WHo?");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameController.bananaEaten)
        {
        transform.position += new Vector3(0f, 0.006f, 0f);
        }
        else
        {
            transform.position += new Vector3(0f, 0f, 0f);
        }
    }
}
