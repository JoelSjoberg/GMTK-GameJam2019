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
    [SerializeField] Transform player;
    MeshRenderer mr;
    SphereCollider sc;
    Animator anim;
    public bool moving;
    int pointsAchieved;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        mr = GetComponent<MeshRenderer>();
        sc = GetComponent<SphereCollider>();

        player = FindObjectOfType<PlayerShoot>().transform;

        anim = GetComponent<Animator>();
        // Makes sure the ball stays in place
        stop();
        pointsAchieved = 0;
    }

    // Launch ball from player position
    public void shoot(Vector3 dir, Vector3 spawnPos)
    {
        if (!moving)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/throw");
            transform.position = spawnPos;
            rb.isKinematic = false;
            rb.AddForce(dir.normalized * initial_velocity);
            current_velocity = rb.velocity.magnitude;
            moving = true;
            mr.enabled = true;
            sc.enabled = true;
            pointsAchieved = 0;
            anim.SetTrigger("shoot");
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

        if (GameStatusManager.points > GameStatusManager.highscore) GameStatusManager.highscore = GameStatusManager.points;
        // Increase game "speed", ugly hardcoding here, but it will have to do in the interrest of time.
        GameStatusManager.spawnRate -= 0.2f;
        if (GameStatusManager.spawnRate <= 1.5) GameStatusManager.spawnRate = 1.5f;
    }

    private void FixedUpdate()
    {
        // If velocity increases
        if (current_velocity < rb.velocity.magnitude) current_velocity = rb.velocity.magnitude;
        // if it decreased however, retain the same speed!
        else if (current_velocity > max_velocity)
        {
            current_velocity = max_velocity;
            rb.velocity = rb.velocity.normalized * max_velocity;
        }
        else rb.velocity = rb.velocity.normalized * current_velocity;

        if (!moving)
        {
            transform.position = player.position;
        }
        transform.LookAt(rb.velocity + transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        anim.SetTrigger("hit");
        
        if (collision.transform.tag == "Player")
        {
            stop();
        }

        // The thief AI should have a kill function which disarms it
        if (collision.transform.tag == "thief")
        {
            
            pointsAchieved += 100;
            collision.transform.GetComponent<AIBehaviour>().kill();
            //collision.transform.SendMessage("kill"); 
        }

        if (collision.transform.tag == "start")
        {

            collision.transform.GetComponent<StartNode>().kill();
            //collision.transform.SendMessage("kill");
        }

        if (collision.transform.tag == "wall")
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Bounce");
        }

        current_velocity += collision_increment;

        collision.transform.SendMessage("shake");
    }
}
