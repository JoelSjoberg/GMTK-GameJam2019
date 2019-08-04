using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHitAi : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "thief")
        {
            anim.SetTrigger("hit");
            print("PlayerHitThief!");
            collision.transform.GetComponent<shakeOnImpact>().shake();
            collision.transform.GetComponent<AIBehaviour>().kill();

            collision.transform.SendMessage("shake");
            collision.transform.SendMessage("kill");
        } 
    }
}
