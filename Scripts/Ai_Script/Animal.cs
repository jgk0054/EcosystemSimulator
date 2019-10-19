using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]

public class Animal : MonoBehaviour
{
    public int health = 100;
    public float hunger = 10;
    public float mating_desire = 0;
    public float speed = 10;
    public float bmr = 1;

    //How far an animal can see.
    public int sightRadius = 10;

    //Threshold at which animal will seek food.
    public float hungerThreshold = 7;


    //Threshold at which animal will seek a mate.
    public float matingThreshold = 5;

    public bool hasTarget = false;

    //Navigation target
    public GameObject target;
    public NavMeshAgent agent;


    public LayerMask foodMask;
    public enum behaviours
    {
        random = 0,
        feeding = 1,
        mating = 2,
    }

    public enum genders
    {
        male = 0,
        female = 1
    }

    //Random by default
    public behaviours behaviour = behaviours.random;
    public genders gender = genders.female;

    //The point we are currently navigating too.
    public Vector3 objective = new Vector3(0, 0, 0);

    void Start()
    {
        agent.speed = this.speed;
        target = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(this.transform.position, target.transform.position);

        /*
        We need to determine what behaviour we are going with.
        We default to random wandering about. If we hit any thresholds we
        switch to that behaviour unit its done.
        */
        //If we have a random behaviour run an analysis to determine if we should switch.

        if (this.hunger < hungerThreshold)
        {
            this.behaviour = behaviours.feeding;
            //Always null out target on behaviour change.
            hasTarget = false;
        }

        if (behaviour == behaviours.random)
        {

            random();
        }

        if (behaviour == behaviours.mating)
        {

        }

        if (behaviour == behaviours.feeding)
        {
            feeding();
        }


    }

    private void FixedUpdate()
    {
        this.hunger -= this.bmr / 100;
    }

    //We select a random point with x units and go there.
    void random()
    {

        if (hasTarget == false)
        {
            //Find a random target


            Vector3 direction = ((Random.insideUnitSphere.normalized * sightRadius) + this.transform.position);


            NavMeshHit hit;
            NavMesh.Raycast(this.transform.position, direction, out hit, NavMesh.AllAreas);

            target.transform.position = hit.position;


            agent.SetDestination(target.transform.position);
            hasTarget = true;
        }

        if (Vector3.Distance(target.transform.position, this.transform.position) < 2)
        {

            hasTarget = false;

        }

    }


    //We find the nearest food and eat it.
    void feeding()
    {
        //Firstly we need to find food.


        // Cast a sphere wrapping character controller 10 meters forward
        // to see if it is about to hit anything.
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, this.sightRadius);
        int i = 0;
        Transform nearest = null;
        float nearDist = 9999;
        while (i < hitColliders.Length)
        {
            float thisDist = (transform.position - hitColliders[i].transform.position).sqrMagnitude;
            if (thisDist < nearDist)
            {
                nearDist = thisDist;
                nearest = hitColliders[i].transform;
            }
            i++;
        }
        Debug.Log("Nearest: " + nearest);
    }

    //We find the nearest neighbor of the same species and opposite gender and mate with it.
    void mating()
    {

    }

    //Reproduce.
    void mate()
    {

    }

    //Find new coordinates to go to.
    void getNewObjective()
    {

    }

    //Go to our objective coordinates.
    void goToObjective()
    {
        //Firstly we always star .1 above the ground.

    }
}
