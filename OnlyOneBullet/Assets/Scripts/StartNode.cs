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

    public void kill()
    {
        
        GameStatusManager.points = 0;
        Destroy(this.gameObject, 0.5f);
        foreach (SpawnEnemy s in spawns) 
        {
            s.activated = true;
        }
        // dirty hack, but will have to do ;D
        if (GameStatusManager.points == 0) FMODUnity.RuntimeManager.PlayOneShot("event:/bgm");
        
    }
}
