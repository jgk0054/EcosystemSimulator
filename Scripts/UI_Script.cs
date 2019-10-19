using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Script : MonoBehaviour
{
    [Header("List of spawnables")]
    public GameObject bush;
    public GameObject tree;
    public GameObject rabbit;
    public GameObject food;
    [Header("Spawner Script Ref")]
    public GenerateObject objectGen;

    public void selectTree()
    {
        objectGen.prefab = tree;
    }

    public void selectBush()
    {
        objectGen.prefab = bush;
    }

    public void selectRabbit()
    {
        objectGen.prefab = rabbit;
    }

    public void selectFood()
    {
        objectGen.prefab = food;
    }
}
