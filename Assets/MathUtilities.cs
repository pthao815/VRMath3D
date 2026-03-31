using UnityEngine;

public static class MathUtilities
{
    // Tính vector pháp tuyến từ 3 điểm
    public static Vector3 GetNormal(Vector3 a, Vector3 b, Vector3 c)
    {
        return Vector3.Cross(b - a, c - a).normalized;
    }

    // Kiểm tra 2 vector có song song không
    public static bool AreParallel(Vector3 v1, Vector3 v2, 
                                    float tolerance = 0.01f)
    {
        return Vector3.Cross(v1.normalized, 
                             v2.normalized).magnitude < tolerance;
    }

    // Kiểm tra 3 điểm có thẳng hàng không
    public static bool AreCollinear(Vector3 a, Vector3 b, Vector3 c, 
                                     float tolerance = 0.01f)
    {
        return Vector3.Cross(b - a, c - a).magnitude < tolerance;
    }
}