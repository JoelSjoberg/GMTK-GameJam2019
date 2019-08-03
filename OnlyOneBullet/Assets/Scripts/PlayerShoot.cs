using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    BallPhysics ball;

    [SerializeField] Vector3 bulletOffset;
    // Start is called before the first frame update
    private void Start()
    {
        if (ball == null) ball = FindObjectOfType<BallPhysics>();
    }

    Vector3 dir;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {

            dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            if (dir.normalized.magnitude < 1) print(dir);
            ball.shoot(dir, transform.position + bulletOffset);
        }
    }
}
