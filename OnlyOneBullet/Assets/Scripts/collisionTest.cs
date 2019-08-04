using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionTest : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "bullet")
        {
            transform.parent.GetComponent<StartNode>().kill();
            transform.parent.GetComponent<shakeOnImpact>().shake();
        }
    }

}
