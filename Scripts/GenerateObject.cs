using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GenerateObject : MonoBehaviour
{
    public Camera cam;
    public GameObject prefab;
    public NavMeshSurface navMesh;
    public UI_Script ui_script;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!ui_script.canSpawn) return;

            Debug.Log("Left mouse clicked");
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(prefab, hit.point, Quaternion.identity);
                navMesh.BuildNavMesh();
                print("My object is clicked by mouse");

            }
        }
    }
}