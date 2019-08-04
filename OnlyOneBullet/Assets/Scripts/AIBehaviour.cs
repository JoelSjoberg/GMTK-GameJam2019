
using UnityEngine;
using UnityEngine.AI;

public class AIBehaviour : MonoBehaviour
{

    NavMeshAgent na;
    licourBox[] goals;
    Vector3 goalPos;
    int currIndex;
    Rigidbody rb;
    bool dead;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        na = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        goalPos = getRandomGoal();
        dead = false;
    }

   

    // Update is called once per frame
    void Update()
    {
        if (currIndex >= goals.Length)
        {
            goalPos = transform.position;
            na.SetDestination(goalPos);
        }
        else if (goals[currIndex] == null && !dead)
        {
            goalPos = getRandomGoal();
        }
        else
        {
            na.SetDestination(goalPos);
        }
    }
    

    Vector3 getRandomGoal()
    {
        goals = FindObjectsOfType<licourBox>();
        currIndex = (int)Random.Range(0, goals.Length);
        if (goals[currIndex] == null)
        {
            dead = true;
            return transform.position;
        }
        else return goals[currIndex].transform.position;

    }


    // called when hit by bullet
    public void kill()
    {
        anim.SetTrigger("hit");
        dead = true;
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        goalPos = transform.position;
        Destroy(this.gameObject, 1f);
    }


    // Redundant, does the exact same thing as kill, but I am afraid of removing it...
    public void dissapear()
    {
        anim.SetTrigger("hit");
        dead = true;
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        goalPos = transform.position;
        Destroy(this.gameObject, 0.2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "beer")
        {
            collision.transform.SendMessage("takeDamage");
            collision.transform.SendMessage("shake");

            dissapear();
        }
    }

}
