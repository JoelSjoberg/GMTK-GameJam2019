using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : MonoBehaviour
{

    [SerializeField] SpawnEnemy[] spawns;

    void Start()
    {
        
    }

    public void kill()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/bgm");
        GameStatusManager.points = 0;
        Destroy(this.gameObject, 0.5f);
        foreach (SpawnEnemy s in spawns) 
        {
            s.activated = true;
        }
        
        
    }
}
