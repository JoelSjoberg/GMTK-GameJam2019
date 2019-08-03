using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : MonoBehaviour
{

    [SerializeField] SpawnEnemy[] spawns;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void kill()
    {
        Destroy(this.gameObject, 2f);
        foreach (SpawnEnemy s in spawns) 
        {
            s.activated = true;
        }
    }
}
