using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TeleportVignette : MonoBehaviour
{
    public Volume volume;
    public float vignetteIntensity = 0.8f;
    public float fadeSpeed = 3f;

    private Vignette vignette;
    private float targetIntensity = 0f;

    void Start()
    {
        if (volume.profile.TryGet(out vignette))
            vignette.intensity.value = 0f;
    }

    void Update()
    {
        if (vignette == null) return;
        vignette.intensity.value = Mathf.Lerp(
            vignette.intensity.value,
            targetIntensity,
            Time.deltaTime * fadeSpeed
        );
    }

    public void OnTeleportStart()
    {
        targetIntensity = vignetteIntensity;
    }

    public void OnTeleportEnd()
    {
        targetIntensity = 0f;
    }
}