using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningScript : MonoBehaviour {

    private GameObject[] röhren;
    public GameObject röhrenPrefab;
    public int röhrenAnzahl = 5;
    private int röhrenZykus = 0;
    public float minRandomRange = -6f;
    public float maxRandomRange = -1f;
    private float spawnTime;
    public float spawnRate = 5f;
    private Vector2 röhrenPosition = new Vector2(-15, -25);
   
    // Use this for initialization
    void Start () {
        spawnTime = 0f;
        röhren = new GameObject[röhrenAnzahl];
        for(int i = 0; i < röhren.Length; i++) {
            röhren[i] = Instantiate(röhrenPrefab, röhrenPosition, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
        spawnTime += Time.deltaTime;

        if (!GameController.instance.gameOver && spawnTime >= spawnRate)
        {
            spawnTime = 0f;

            float randomYSpawnposition = Random.Range(minRandomRange, maxRandomRange);

            röhren[röhrenZykus].transform.position = new Vector2(16f, randomYSpawnposition);

            röhrenZykus++;

            if (röhrenZykus >= röhrenAnzahl)
            {
                röhrenZykus = 0;
            }

        }
	}
}
