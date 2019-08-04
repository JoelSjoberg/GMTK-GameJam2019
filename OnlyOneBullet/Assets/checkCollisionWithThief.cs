using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCollisionWithThief : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "thief")
        {
            print("Thief entered");
            GetComponent<licourBox>().takeDamage();
            other.transform.GetComponent<AIBehaviour>().dissapear();
        }
    }
}
