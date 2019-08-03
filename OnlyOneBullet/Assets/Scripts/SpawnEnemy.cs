using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;

    float timer = 0, spawnRate, noise;
    public bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        noise = Random.Range(0.5f, 4f);
        spawnRate = GameStatusManager.spawnRate + noise;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (activated)
        {
            timer += Time.deltaTime;
        }

        if (timer >= spawnRate)
        {
            Instantiate(enemyPrefab, transform);
            timer = 0;

            // if spawnrate decreases then update it

            if (spawnRate - noise > GameStatusManager.spawnRate)
            {
                noise = Random.Range(0.5f, 4f);
                spawnRate = GameStatusManager.spawnRate + noise;

            }
        }
    }
}
