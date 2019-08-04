using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{

    CharacterController ch;

    [SerializeField] float speed, maxSpeed, acceleration, decelleration;

    // In case a bot pushes the player aside, lock the z axis
    float initialZ;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        ch = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        initialZ = transform.position.z;
    }

    public Vector3 velocity;

    private void Update()
    {
        getInput();
    }

    private void FixedUpdate()
    {
        getInput();

        if (inputVec.magnitude > 0) accelerate();
        else decell();
        ch.Move(velocity);


    }

    private void LateUpdate()
    {

        // Lock player position to the floor to awoid game breaking collision/slope climbing with bullet
        transform.position = new Vector3(transform.position.x, 0, initialZ);

        // In some cases for example if the player is moving agains the wall, the velocity of the character controller should be 0, and so should the vector velocity
        if(ch.velocity.magnitude == 0) velocity = ch.velocity;
    }

    Vector3 inputVec;

    void getInput()
    {
        inputVec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0).normalized * Time.deltaTime;
        if (inputVec.magnitude > 0) anim.SetBool("idle", false);
        else anim.SetBool("idle", true);
    }

    void decell()
    {
        velocity -= velocity * decelleration * speed * Time.fixedDeltaTime;
        if (velocity.magnitude <= 0.01) velocity = Vector3.zero;
    }

    void accelerate()
    {
        velocity += inputVec * acceleration * speed *  Time.fixedDeltaTime;
        if (velocity.magnitude >= maxSpeed) velocity = velocity.normalized * maxSpeed; 
    }
}
