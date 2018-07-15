using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatScript : MonoBehaviour {

    private BoxCollider2D box2d;
    private float groundLenght;
	// Use this for initialization
	void Start () {
        box2d = GetComponent<BoxCollider2D>();
        groundLenght = box2d.size.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < -groundLenght)
        {
            ShiftBackground();
        }
	}

    void ShiftBackground()
    {   
            transform.position = new Vector2(groundLenght, transform.position.y);   
    }
}
