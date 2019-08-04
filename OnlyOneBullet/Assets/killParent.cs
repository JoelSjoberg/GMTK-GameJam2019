using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killParent : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "bullet" || other.tag == "Player")
        {
            transform.parent.GetComponent<AIBehaviour>().kill();
            transform.parent.GetComponent<shakeOnImpact>().shake();
        }

        if (other.tag == "beer")
        {

            print("BEER!");
            other.GetComponent<licourBox>().takeDamage();
            transform.parent.GetComponent<AIBehaviour>().dissapear();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "beer")
        {

            print("BEER!");
            collision.transform.GetComponent<licourBox>().takeDamage();
            transform.parent.GetComponent<AIBehaviour>().dissapear();
        }
    }
}
