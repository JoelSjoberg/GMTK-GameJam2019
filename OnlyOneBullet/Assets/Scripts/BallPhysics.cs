using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float max_velocity;
    [SerializeField] float initial_velocity;
    [SerializeField] float current_velocity;

    [SerializeField] float collision_increment = 0.01f;

    public bool moving;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Makes sure the ball stays in place
        stop();
    }

    // Launch ball from player position
    public void shoot(Vector3 dir, Vector3 spawnPos)
    {
        if (!moving)
        {
            transform.position = spawnPos;
            rb.isKinematic = false;
            rb.AddForce(dir.normalized * initial_velocity);
            current_velocity = rb.velocity.magnitude;
            moving = true;
        }
    }

    // Stop all movement
    public void stop()
    {
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        moving = false;

    }

    private void FixedUpdate()
    {
        // If velocity increases
        if (current_velocity < rb.velocity.magnitude) current_velocity = rb.velocity.magnitude;
        // if it decreased however, retain the same speed!
        else rb.velocity = rb.velocity.normalized * current_velocity;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            stop();
        }
        print("Ball hit: " + collision.transform.tag);

        current_velocity += collision_increment;
    }
}
