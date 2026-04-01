using UnityEngine;

public class PlaneTool : MonoBehaviour
{
    private Vector3[] points = new Vector3[3];
    private int pointCount = 0;

    void Update()
    {
        bool triggered = false;

        #if UNITY_EDITOR
        triggered = Input.GetMouseButtonDown(0);
        #else
        triggered = OVRInput.GetDown(
            OVRInput.Button.PrimaryIndexTrigger);
        #endif

        if (triggered)
        {
            Vector3 pos;

            #if UNITY_EDITOR
            // Trên PC dùng vị trí ngẫu nhiên để test
            pos = new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f)
            );
            #else
            pos = transform.position;
            #endif

            points[pointCount] = pos;
            pointCount++;
            Debug.Log("Điểm " + pointCount + ": " + points[pointCount - 1]);

            if (pointCount == 3)
            {
                if (MathUtilities.AreCollinear(
                    points[0], points[1], points[2]))
                {
                    Debug.LogWarning("3 điểm thẳng hàng!");
                }
                else
                {
                    BuildPlane(points[0], points[1], points[2]);
                }
                pointCount = 0;
            }
        }
    }

    void BuildPlane(Vector3 a, Vector3 b, Vector3 c)
    {
        Vector3 d = a + (c - b);
        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[] { a, b, c, d };
        mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
        mesh.RecalculateNormals();

        GameObject planeObj = new GameObject("Plane3Points");
        planeObj.AddComponent<MeshFilter>().mesh = mesh;
        MeshRenderer mr = planeObj.AddComponent<MeshRenderer>();
        mr.material = new Material(
            Shader.Find("Universal Render Pipeline/Lit"));
    }
}