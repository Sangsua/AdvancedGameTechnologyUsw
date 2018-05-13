using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField]
    float velocity = 4;
    public int hitScore;
    // Use this for initialization
    public GameController gameController;

    void Start()
    {

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Thereisnospoon");
        }


    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        
        Destroy(this.gameObject);
        gameController.IncrementScore(hitScore);
    }


    void Update () {
        transform.position += Vector3.up * Time.deltaTime * velocity;

        if (transform.position.y > 9f)
        {
            Destroy(this.gameObject);
        }
        
     
    }
}
