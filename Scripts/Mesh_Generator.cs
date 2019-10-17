using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(NavMeshSurface))]
public class Mesh_Generator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    Color[] colors;

    public int xSize = 20;
    public int zSize = 20;

    public Gradient gradient;

    private float minTerrianHeight;
    private float maxTerrianHeight;
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateShape();
        UpdateMesh();
        BuildNavMesh();

    }

    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        //I tracks the index of the vertice we are looping over.
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * .1f, z * .1f) * 1f;
                vertices[i] = new Vector3(x, y, z);

                if (y > maxTerrianHeight)
                {
                    maxTerrianHeight = y;
                }
                if (y < minTerrianHeight)
                {
                    minTerrianHeight = y;
                }

                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];
        int vert = 0;
        int tris = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[0 + tris] = vert + 0;
                triangles[1 + tris] = vert + xSize + 1;
                triangles[2 + tris] = vert + 1;
                triangles[3 + tris] = vert + 1;
                triangles[4 + tris] = vert + xSize + 1;
                triangles[5 + tris] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }

        colors = new Color[vertices.Length];
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float height = Mathf.InverseLerp(minTerrianHeight, maxTerrianHeight,  vertices[i].y);
                colors[i] = gradient.Evaluate(height);
                i++;
            }
        }


    }

    void UpdateMesh()
    {
        MeshCollider myMC = GetComponent<MeshCollider>();
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colors;
        mesh.RecalculateNormals();
        myMC.sharedMesh = mesh;

    }


    void BuildNavMesh()
    {
        NavMeshSurface surface = GetComponent<NavMeshSurface>();
        surface.BuildNavMesh();

    }
    /*
    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }
    */
}
