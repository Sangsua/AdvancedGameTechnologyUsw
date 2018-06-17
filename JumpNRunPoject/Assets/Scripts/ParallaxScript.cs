using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{

    private Transform[] backgrounds;
    private new  Transform  camera;
    public float backgroundsize = 19.2f;
    public float parallaxScaling;

    private Vector3 previousCameraPosition;
    private int leftSide;
    private int rightSide;
    private float view = 20;
    private float lastXPosition;

    private void Awake()
    {
        camera = Camera.main.transform;

    }
    // Use this for initialization
    void Start()
    {
        lastXPosition = camera.position.x;
        backgrounds = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            backgrounds[i] = transform.GetChild(i);
        }
        leftSide = 0;
        rightSide = backgrounds.Length - 1;
    }


    // Update is called once per frame
    void Update()
    {
        float deltaX = camera.transform.position.x - lastXPosition;
        transform.position += Vector3.right * (deltaX * parallaxScaling);
        lastXPosition = camera.position.x;
        if (camera.position.x < (backgrounds[leftSide].transform.position.x + view)){
            ScrollLeft();
        }
        if (camera.position.x > (backgrounds[rightSide].transform.position.x - view)){
            ScrollRight();
        }
    }
    private void ScrollLeft()
    {
        backgrounds[rightSide].position = Vector3.right * (backgrounds[leftSide].position.x - backgroundsize);

        leftSide = rightSide;
        rightSide--;
        if (rightSide < 0)
        {
            rightSide = backgrounds.Length - 1;
        }
    }
    private void ScrollRight()
    {

        backgrounds[leftSide].position = Vector3.right * (backgrounds[rightSide].position.x + backgroundsize);

        rightSide = leftSide;
        leftSide++;
        if (leftSide == backgrounds.Length)
        {
            leftSide = 0;
        }
    }
}