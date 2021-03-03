using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Feed : Job
{
    private bool foundFood = true;
    public Feed()
    {
        this.JobType = "feed";
        this.JobRadius = 1;
    }

    public override GameObject findTarget(Animal subject)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Food");
        
        //No food. :(
        if(gos.Length == 0)
        {
            Vector3 direction = (Random.insideUnitSphere.normalized * subject.sightRadius) + subject.transform.position;
            UnityEngine.AI.NavMeshHit hit;
            UnityEngine.AI.NavMesh.Raycast(subject.transform.position, direction, out hit, UnityEngine.AI.NavMesh.AllAreas);
            GameObject go = new GameObject();
            go.transform.position = hit.position;
            this.foundFood = false;
            return go;
        }
        
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = subject.transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    public override void reachedTarget(Animal subject, GameObject target)
    {
        UnityEngine.Object.Destroy(target);
        if (this.foundFood)
        {
            subject.hunger += 10;
        }
    }
    public override GameObject setTarget(GameObject target)
    {
        return base.setTarget(target);
    }

}

