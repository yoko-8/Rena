using UnityEngine;

public class DrawOnSubmit : MonoBehaviour
{
    public int width = 1920;
    public int height = 1080;

    public Texture2D drawing;

    void OnMouseDown()
    {
        RenderTexture renderTexture = new RenderTexture(width, height, 24);
        Camera.main.targetTexture = renderTexture;
        Texture2D screenshot = new Texture2D(width, height, TextureFormat.RGB24, false);
        Camera.main.Render();
        RenderTexture.active = renderTexture;
        screenshot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        Camera.main.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);
        drawing = screenshot;
    }
}
