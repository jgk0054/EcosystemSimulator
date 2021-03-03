using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


class Idle : Job
{
    public Idle()
    {
        this.JobType = "random";
        this.JobRadius = 1;
    }

    public override GameObject findTarget(Animal subject)
    {
        Vector3 direction = (Random.insideUnitSphere.normalized * subject.sightRadius) + subject.transform.position;
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.Raycast(subject.transform.position, direction, out hit, UnityEngine.AI.NavMesh.AllAreas);
        GameObject go = new GameObject();
        go.transform.position = hit.position;
        return go;
    }

    public override void reachedTarget(Animal subject, GameObject target)
    {
        Debug.Log("Destroying old target, generating new one.");
        UnityEngine.Object.Destroy(target);
    }
    public override GameObject setTarget(GameObject target)
    {
        return base.setTarget(target);
    }

}

