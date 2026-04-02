using UnityEngine;
using System.Collections.Generic;

public class SnapSystem : MonoBehaviour
{
    public static SnapSystem Instance;
    public float snapDistance = 0.05f;
    
    private List<Vector3> registeredPoints = new List<Vector3>();

    void Awake()
    {
        Instance = this;
    }

    // Đăng ký điểm mới vào hệ thống snap
    public void RegisterPoint(Vector3 point)
    {
        registeredPoints.Add(point);
    }

    // Kiểm tra và hút vào điểm gần nhất
    public Vector3 Snap(Vector3 position)
    {
        Vector3 closest = position;
        float minDist = snapDistance;

        foreach (Vector3 pt in registeredPoints)
        {
            float dist = Vector3.Distance(pt, position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = pt;
            }
        }

        return closest;
    }

    // Xóa tất cả điểm
    public void ClearPoints()
    {
        registeredPoints.Clear();
    }
}