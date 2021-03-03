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
    public int sightRadius = 5;
    public float fov = 90;

    //Threshold at which animal will seek food.
    public float hungerThreshold = 7;


    //Threshold at which animal will seek a mate.
    public float matingThreshold = 5;

    public bool hasTarget = false;

    //Navigation target
    public GameObject target;
    public NavMeshAgent agent;

    public enum genders
    {
        male = 0,
        female = 1
    }

    //Random by default
    public genders gender = genders.female;

    //List of jobs
    public List<Job> jobs = new List<Job>();

    //The point we are currently navigating too.
    public Vector3 objective = new Vector3(0, 0, 0);

    void Start()
    {
        agent.speed = this.speed;
        jobs.Add(new Idle());
        target = jobs[0].findTarget(this);
        agent.SetDestination(target.transform.position);
        hasTarget = true;
    }

    // Update is called once per frame
    void Update()
    {

        //If we don't have a job, idle.
        if (this.jobs.Count <= 0)
        {
            jobs.Add(new Idle());
        }

        //If we don't have a target, find one.
        if (!this.hasTarget)
        {
            target = jobs[0].findTarget(this);
            agent.SetDestination(target.transform.position);
            hasTarget = true;
        }




        //Behaviour

        //If we are hungry, add a feed job. Does a hard interupt of all current activities.
        if (this.hunger < hungerThreshold && jobs.Find(item => item.JobType.Equals("feed")) == null)
        {
            Destroy(target);
            this.jobs.Clear();
            this.jobs.Add(new Feed());
            target = jobs[0].findTarget(this);
            agent.SetDestination(target.transform.position);
        }


        //End the job if we are close enough to it to trigger ending.
        if (Vector3.Distance(target.transform.position, this.transform.position) < jobs[0].JobRadius)
        {
            jobs[0].reachedTarget(this, target);
            jobs.RemoveAt(0);
            hasTarget = false;
        }
        if (target != null)
        {
            Debug.DrawLine(this.transform.position, target.transform.position);
        }

    }

    private void FixedUpdate()
    {
        this.hunger -= this.bmr / 100;
    }
}
