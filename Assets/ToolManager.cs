using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public PointTool pointTool;
    public LineTool lineTool;
    public PlaneTool planeTool;

    void Start()
{
    // Chuyển sang InteractiveMode khi start
    LessonStateMachine lsm = GetComponent<LessonStateMachine>();
    if (lsm != null)
        lsm.SetInteractiveMode();
    
    SetAllToolsOff();
}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ActivatePointTool();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            ActivateLineTool();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            ActivatePlaneTool();
    }

    void SetAllToolsOff()
    {
        if (pointTool) pointTool.enabled = false;
        if (lineTool) lineTool.enabled = false;
        if (planeTool) planeTool.enabled = false;
    }

    public void ActivatePointTool()
    {
        SetAllToolsOff();
        if (pointTool) pointTool.enabled = true;
        Debug.Log("Đã chọn: Point Tool");
    }

    public void ActivateLineTool()
    {
        SetAllToolsOff();
        if (lineTool) lineTool.enabled = true;
        Debug.Log("Đã chọn: Line Tool");
    }

    public void ActivatePlaneTool()
    {
        SetAllToolsOff();
        if (planeTool) planeTool.enabled = true;
        Debug.Log("Đã chọn: Plane Tool");
    }
}