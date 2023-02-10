using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class RandomNav : MonoBehaviour
{
    //Declare Variables
    private NavMeshAgent agent;
    //[SerializeField] private Animator myAnimationController;
    private Transform myTrans;
    public float patrolRadius = 50f;
    public float patrolTimer = 6f;
    private float timer;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        myTrans = transform;

    }

    void Update()
    {
        //myAnimationController.SetBool("Walk", true);
        Patrol();

    }

    void Patrol()
    {
        timer += Time.deltaTime;
        if (timer > patrolTimer)
        {
            ChooseNewRandomDestination();
            timer = 0f;
        }
    }

    void ChooseNewRandomDestination()
    {
        //Projects a point on the navigation grid within a sphere
        Vector3 newPoint = RandomPointSelect(transform.position, patrolRadius);

        //Set Destination to new Vector3 point
        agent.SetDestination(newPoint);
    }

    Vector3 RandomPointSelect(Vector3 origin, float radius)
    {
        //Note: Unit Sphere = radius of 1 centered at the origin of global space

        //Create a sphere of a certain radius 
        Vector3 randPoint = Random.insideUnitSphere * radius;

        //AND move it's center to the object this script is attached to
        randPoint += origin;

        //Create a local variable
        NavMeshHit navHit;

        //Project the sphere onto the NavMesh and generate an output variable
        NavMesh.SamplePosition(randPoint, out navHit, radius, -1);

        //Pass back the randomly selected position within the sphere
        return navHit.position;

    }
}
