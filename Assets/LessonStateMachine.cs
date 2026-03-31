using UnityEngine;

public class LessonStateMachine : MonoBehaviour
{
    public enum LessonMode { LectureMode, InteractiveMode }
    public LessonMode currentMode = LessonMode.LectureMode;

    public GameObject[] tools;
    public GameObject wristPalette;

    void Start()
    {
        SetMode(currentMode);
    }

    public void SetMode(LessonMode mode)
    {
        currentMode = mode;

        bool isInteractive = mode == LessonMode.InteractiveMode;

        foreach (var tool in tools)
            if (tool != null)
                tool.SetActive(isInteractive);

        if (wristPalette != null)
            wristPalette.SetActive(isInteractive);

        Debug.Log("Chế độ: " + mode);
    }

    public void SetLectureMode() => SetMode(LessonMode.LectureMode);
    public void SetInteractiveMode() => SetMode(LessonMode.InteractiveMode);
}