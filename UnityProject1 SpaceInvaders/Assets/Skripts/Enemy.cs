using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public int speed = 2;
    private int rotationspeed = 600;
    public Shader dissolve;
    public Renderer rend;
    // Use this for initialization
    float linearInterpolationFloat = 0.5f;
    float dissolveFloat;
    void Start()
    {
        rend = GetComponent<Renderer>();
        dissolve = Shader.Find("Diffuse");
        
    }

    // Update is called once per frame

    void Update()
    {
        
        transform.position += Vector3.down * Time.deltaTime * speed;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationspeed);

        if (transform.position.y < -1)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)

    {
        transform.position += Vector3.up * Time.deltaTime * 10;
        dissolveFloat = Mathf.Lerp(1f, 0f, linearInterpolationFloat);
        rend.material.SetFloat("_DissolveFactor", dissolveFloat);
        
        Destroy(this.gameObject, 0.12f);

    }
}
