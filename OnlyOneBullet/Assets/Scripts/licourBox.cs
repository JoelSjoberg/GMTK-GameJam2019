using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class licourBox : MonoBehaviour
{
    public int hp;
    [SerializeField]shakeCam cam;
    // Start is called before the first frame update
    void Start()
    {
        hp = 3;
    }

    public void takeDamage()
    {
        hp -= 1;
        cam.shakeDown();
        if (hp <= 0)
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
