using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakeCam : MonoBehaviour
{
    Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        easeIn();
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, origin, 0.7f);
    }

    public void shakeDown()
    {
        transform.position -= Vector3.forward* 2.5f;
    }

    public void easeIn()
    {
        transform.position += Vector3.forward * 30;
    }

}
