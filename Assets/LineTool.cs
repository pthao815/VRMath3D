using UnityEngine;
using UnityEngine.InputSystem;

public class LineTool : MonoBehaviour
{
    public float pointSize = 0.05f;
    private Vector3 firstPoint;
    private bool hasFirstPoint = false;

    void Update()
    {
        bool triggered = false;

        #if UNITY_EDITOR
        triggered = Mouse.current.leftButton.wasPressedThisFrame;
        #else
        triggered = OVRInput.GetDown(
            OVRInput.Button.PrimaryIndexTrigger);
        #endif

        if (triggered)
        {
            if (!hasFirstPoint)
            {
                firstPoint = transform.position;
                hasFirstPoint = true;
                Debug.Log("Điểm 1: " + firstPoint);
            }
            else
            {
                Vector3 secondPoint = transform.position;
                DrawLine(firstPoint, secondPoint);
                hasFirstPoint = false;
            }
        }
    }

    void DrawLine(Vector3 start, Vector3 end)
    {
        GameObject lineObj = new GameObject("Line");
        LineRenderer lr = lineObj.AddComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        lr.startWidth = 0.01f;
        lr.endWidth = 0.01f;
    }
}