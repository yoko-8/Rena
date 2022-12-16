using System.Collections.Generic;
using UnityEngine;

public class CrayonController : MonoBehaviour
{
    public GameObject crayonPrefab;
    public GameObject currentLine;
    public GameObject canvas;

    public LineRenderer lineRenderer;
    public List<Vector2> linePositions;
    public Color currentColor = Color.black;

    private int currentLayerOrder;
    private readonly LinkedList<GameObject> lines = new LinkedList<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        currentLayerOrder = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(currentPosition, linePositions[linePositions.Count - 1]) > .1f)
            {
                UpdateLine(currentPosition);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (currentColor.Equals(Color.clear))
            {
                Undo();
            }
        }
    }

    private void CreateLine()
    {
        currentLine = Instantiate(crayonPrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        lineRenderer.material.SetColor("_Color", currentColor);
        lineRenderer.sortingOrder = currentLayerOrder++;
        linePositions.Clear();
        linePositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        linePositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, linePositions[0]);
        lineRenderer.SetPosition(1, linePositions[1]);
        lines.AddLast(currentLine);
    }

    private void UpdateLine(Vector2 newCursorPos)
    {
        linePositions.Add(newCursorPos);
        lineRenderer.SetPosition(lineRenderer.positionCount++, newCursorPos);
    }

    public void ClearAll()
    {
        foreach (var line in lines)
        {
            Destroy(line);
        }
    }

    public void Undo()
    {
        var last = lines.Last.Value;
        lines.RemoveLast();
        Destroy(last);
    }
}
