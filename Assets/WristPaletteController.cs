using UnityEngine;

public class WristPaletteController : MonoBehaviour
{
    public GameObject wristPalette;
    public float showAngle = 45f;

    void Update()
    {
        if (wristPalette == null) return;

        // Tính góc giữa mặt trên cổ tay và hướng camera nhìn
        float angle = Vector3.Angle(
            transform.up,
            Camera.main.transform.forward
        );

        // Nếu góc nhỏ hơn ngưỡng → đưa tay lên ngang mắt → hiện menu
        wristPalette.SetActive(angle < showAngle);
    }
}