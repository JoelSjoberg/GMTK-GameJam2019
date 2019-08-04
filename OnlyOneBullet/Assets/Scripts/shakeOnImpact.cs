using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakeOnImpact : MonoBehaviour
{
    Vector3 pos;


    public void shake()
    {
        pos = transform.position;
        StartCoroutine("shakeWithReturn"); 
    }

    IEnumerator shakeWithReturn()
    {
        float timer = 0;
        

        while(timer < 0.3f)
        {
            // return
            transform.position = pos;

            // offset for shake, ignore y-axis, shake only on x and z

            Vector3 offset = Random.insideUnitCircle;
            offset.z = offset.y;
            offset.y = 0;
            offset = offset.normalized * 0.1f;
            transform.position = transform.position + offset;
            timer += Time.deltaTime;
            yield return null; 
        }
        transform.position = pos;
        yield return 0;
    }

}
