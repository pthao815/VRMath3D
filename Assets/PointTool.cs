// using UnityEngine;
// using UnityEngine.InputSystem;

// public class PointTool : MonoBehaviour
// {
//     public float pointSize = 0.05f;

//     void Update()
//     {
//         bool triggered = false;

//         #if UNITY_EDITOR
//         // Trên PC dùng chuột trái để test
//         triggered = Mouse.current.leftButton.wasPressedThisFrame;
//         #else
//         // Trên Quest 2 dùng trigger tay phải
//         triggered = OVRInput.GetDown(
//             OVRInput.Button.PrimaryIndexTrigger);
//         #endif

//         if (triggered)
//         {
//             CreatePoint(transform.position);
//         }
//     }

//     void CreatePoint(Vector3 position)
//     {
//         GameObject point = GameObject.CreatePrimitive(
//             PrimitiveType.Sphere);
//         point.transform.position = position;
//         point.transform.localScale = Vector3.one * pointSize;
//     }
// }

using UnityEngine;

public class PointTool : MonoBehaviour
{
    public float pointSize = 0.05f;

    void Update()
    {
        bool triggered = false;

        #if UNITY_EDITOR
        triggered = Input.GetMouseButtonDown(0);
        if (triggered)
            Debug.Log("PointTool triggered!");
        #else
        triggered = OVRInput.GetDown(
            OVRInput.Button.PrimaryIndexTrigger);
        #endif

        if (triggered)
        {
            CreatePoint(transform.position);
        }
    }

    void CreatePoint(Vector3 position)
    {
        GameObject point = GameObject.CreatePrimitive(
            PrimitiveType.Sphere);
        point.transform.position = position;
        point.transform.localScale = Vector3.one * pointSize;
    }
}