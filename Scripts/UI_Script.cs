using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Script : MonoBehaviour
{
    [Header("List of spawnables")]
    public GameObject bush;
    public GameObject tree;

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
}
