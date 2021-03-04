using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(NavMeshSurface))]

public class SphericalMeshGenerator : MonoBehaviour
{
    public Material planetMaterial;
    public float planetSize = 1f;
    Mesh planetMesh;
    Vector3[] planetVertices;
    int[] planetTriangles;
    void Start()
    {
        CreatePlanet();
    }
    public void CreatePlanet()
    {
        CreatePlanetGameObject();
        //do whatever else you need to do with the sphere mesh
        RecalculateMesh();
        BuildNavMesh();
    }

    void CreatePlanetGameObject()
    {
        planetMesh = new Mesh();
        GetComponent<MeshFilter>().mesh = planetMesh;
        //need to set the material up top
        this.transform.localScale = new Vector3(planetSize, planetSize, planetSize);
        IcoSphere.Create(this.gameObject);
    }

    void RecalculateMesh()
    {
        planetMesh.RecalculateBounds();
        planetMesh.RecalculateTangents();
        planetMesh.RecalculateNormals();
    }

    void BuildNavMesh()
    {
        NavMeshSurface surface = GetComponent<NavMeshSurface>();
        surface.BuildNavMesh();
    }
}
