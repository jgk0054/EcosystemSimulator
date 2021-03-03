using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job
{
    //Type of job. Think of it as a tag.
    public virtual string JobType
    {
        get;
        set;
    }
    public virtual int JobRadius
    {
        get;
        set;
    }
    //Initialize the job.
    public virtual void init()
    {

    }

    //Find the target for the job.
    public virtual GameObject findTarget(Animal subject)
    {
        Debug.Log("Should never see this");
        return new GameObject();
    }

    public virtual GameObject setTarget(GameObject target)
    {
        return new GameObject();
    }

    //Execute once you have reached the target.
    public virtual void reachedTarget(Animal subject, GameObject target)
    {
        Debug.Log("Should never see this");
    }
}
