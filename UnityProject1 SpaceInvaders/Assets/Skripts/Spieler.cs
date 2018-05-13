using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spieler : MonoBehaviour
{
    [SerializeField]
    public float defaultSpeed = 1;

    [SerializeField]
    public float speed = 2;
    // Use this for initialization
    [SerializeField]
    GameObject bullet;

    private float rotationspeed = 300f;
    private GameController gameController;
    void Start()
    {
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
    void Update()
    {
        //Controllsm
        ControllPlayer();
        //Destroy if out of Border
        if (transform.position.y < -1 || transform.position.y > 10 || transform.position.x < -7 || transform.position.x > 6)
        {
            Destroy(this.gameObject);
            gameController.GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameController.GameOver();
            Destroy(this.gameObject);
        }
    }

    void ExitBorder()
    {

    }
    void ControllPlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {

            transform.position += Vector3.left * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.Space))
        {// Move with player 
            if (Time.frameCount % 15 == 0)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);

               
            }
        }
        transform.Rotate(Vector3.up* Time.deltaTime * rotationspeed, Space.World);
    }

}
