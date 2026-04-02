using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class PyramidMesh : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-0.5f, 0, -0.5f),
            new Vector3( 0.5f, 0, -0.5f),
            new Vector3( 0.5f, 0,  0.5f),
            new Vector3(-0.5f, 0,  0.5f),
            new Vector3( 0,    1,  0   )
        };

        int[] triangles = new int[]
        {
            0, 1, 2,  0, 2, 3,  // đáy
            0, 4, 1,             // mặt trước
            1, 4, 2,             // mặt phải
            2, 4, 3,             // mặt sau
            3, 4, 0              // mặt trái
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