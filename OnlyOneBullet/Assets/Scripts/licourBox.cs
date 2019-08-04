using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class licourBox : MonoBehaviour
{
    public int hp;
    [SerializeField]shakeCam cam;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        hp = 3;
        anim = GetComponentInChildren<Animator>();
    }

    public void takeDamage()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/booze");
        hp -= 1;
        cam.shakeDown();
        anim.SetTrigger("hit");
        if (hp <= 0)
        {
            Destroy(this.gameObject, 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "thief")
        {
            takeDamage();
            other.GetComponent<AIBehaviour>().dissapear();
        }
        
    }
}
