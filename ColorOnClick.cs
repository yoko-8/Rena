using UnityEngine;

public class ColorOnClick : MonoBehaviour
{
    public CrayonController controller;
    public Color color;

    void OnMouseDown()
    {
        controller.currentColor = color;
    }
}
