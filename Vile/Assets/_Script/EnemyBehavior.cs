using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private Animator myAnimationController;
    private Transform myTrans;
    public GameObject target;
    public float attackDistance;
    public float spotDistance;
    public float speed;
    private RandomNav nav;
    //Attack Delay variables
    public float attackRate;
    private float nextAttack;
    //private AudioSource audio;
    void Start()
    {
        myTrans = transform;
        nav = GetComponent<RandomNav>();
        nextAttack = Time.time;
       
    }

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector3.Distance(myTrans.position, target.transform.position);

        if (distance <= attackDistance)
        {
            nav.enabled = false;
            //myAnimationController.SetBool("Attack", true);

            myTrans.LookAt(target.transform);

            myTrans.position = Vector3.MoveTowards(myTrans.position, target.transform.position, speed * Time.deltaTime);

            /*
            if (Time.time > nextAttack)
            {
                //Subtract player health from spider attack
                GameControl.control.health -= 10;

                //Set timer with a delay of attack rate
                nextAttack = Time.time + attackRate;

                //Check if player's health reaches 0
                if (GameControl.control.health <= 0)
                {
                    //Change to Death Scene
                    SceneManager.LoadScene(6);
                }
            }*/
        }

        else if (distance < spotDistance)
        {
            nav.enabled = false;
            //myAnimationController.SetBool("Attack", false);
                //Look for Animation Component to play specific animation 
            //myAnimationController.SetBool("Walk", true);

            //Make the current object face the target 
            myTrans.LookAt(target.transform);

            //Move the current object in the direction of the target with a set speed over time
            myTrans.position = Vector3.MoveTowards(myTrans.position, target.transform.position, speed * Time.deltaTime);
        }

        //Otherwise, default to idle state
        else
        {
            //Look for Animation Component to play specific animation 
            nav.enabled = true;
        }

    }
}

