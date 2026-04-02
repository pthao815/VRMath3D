using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class TetrahedronMesh : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[]
        {
            new Vector3( 0,    1,    0   ),
            new Vector3( 0,    0,    1   ),
            new Vector3(-0.87f,0,   -0.5f),
            new Vector3( 0.87f,0,   -0.5f)
        };

        int[] triangles = new int[]
        {
            0, 1, 2,
            0, 2, 3,
            0, 3, 1,
            1, 3, 2
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().material =
            new Material(Shader.Find("Universal Render Pipeline/Lit"));

        gameObject.AddComponent<MeshCollider>().sharedMesh = mesh;
    }
}