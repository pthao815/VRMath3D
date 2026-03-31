using UnityEngine;

[ExecuteInEditMode]
public class GridTextureGenerator : MonoBehaviour
{
    public int gridSize = 512;
    public int lineWidth = 2;
    public Color gridColor = new Color(0.2f, 0.5f, 1f, 1f);
    public Color bgColor = new Color(0.1f, 0.1f, 0.18f, 1f);

    void Start()
    {
        ApplyGrid();
    }

    void ApplyGrid()
    {
        Texture2D tex = new Texture2D(gridSize, gridSize);
        Color[] pixels = new Color[gridSize * gridSize];

        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                bool onLine = x < lineWidth || y < lineWidth;
                pixels[y * gridSize + x] = onLine ? gridColor : bgColor;
            }
        }

        tex.SetPixels(pixels);
        tex.Apply();
        tex.wrapMode = TextureWrapMode.Repeat;

        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.sharedMaterial.mainTexture = tex;
        mr.sharedMaterial.SetTextureScale("_BaseMap", new Vector2(5, 5));
    }
}