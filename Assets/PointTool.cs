using UnityEngine;

public class PointTool : MonoBehaviour
{
    public float pointSize = 0.05f;
    public GameObject pointLabelPrefab;
    
    private int pointCount = 0;
    private string[] labels = { "A","B","C","D","E","F","G","H" };

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
            // Dùng Snap để hút vào điểm gần nhất
            Vector3 position = transform.position;
            if (SnapSystem.Instance != null)
                position = SnapSystem.Instance.Snap(position);

            CreatePoint(position);
            
            // Đăng ký điểm vào SnapSystem
            if (SnapSystem.Instance != null)
                SnapSystem.Instance.RegisterPoint(position);
        }
    }

    void CreatePoint(Vector3 position)
    {
        GameObject point = GameObject.CreatePrimitive(
            PrimitiveType.Sphere);
        point.transform.position = position;
        point.transform.localScale = Vector3.one * pointSize;

        if (pointLabelPrefab != null && pointCount < labels.Length)
        {
            GameObject label = Instantiate(pointLabelPrefab);
            label.transform.position = position + Vector3.up * 0.1f;

            Transform labelText = label.transform.Find("Canvas/LabelText");
            if (labelText != null)
            {
                TMPro.TextMeshProUGUI tmp =
                    labelText.GetComponent<TMPro.TextMeshProUGUI>();
                if (tmp != null)
                    tmp.text = labels[pointCount];
            }
        }

        pointCount++;
    }
}