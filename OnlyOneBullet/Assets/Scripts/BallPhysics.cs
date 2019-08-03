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

    MeshRenderer mr;
    SphereCollider sc;

    public bool moving;
    int pointsAchieved;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        mr = GetComponent<MeshRenderer>();
        sc = GetComponent<SphereCollider>();


        // Makes sure the ball stays in place
        stop();

        pointsAchieved = 0;

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
            mr.enabled = true;
            sc.enabled = true;
            pointsAchieved = 0;
        }
    }

    // Stop all movement
    public void stop()
    {
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        moving = false;

        mr.enabled = false;
        sc.enabled = false;
        GameStatusManager.points += pointsAchieved;

        // Increase game "speed", ugly hardcoding here, but it will have to do in the interrest of time.
        GameStatusManager.spawnRate -= 0.2f;
        if (GameStatusManager.spawnRate <= 1.5) GameStatusManager.spawnRate = 1.5f;
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

        // The thief AI should have a kill function which disarms it
        if (collision.transform.tag == "thief")
        {
            pointsAchieved += 100;
            collision.transform.SendMessage("kill");

            
        }
        current_velocity += collision_increment;

        collision.transform.SendMessage("shake");
    }
}
