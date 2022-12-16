using UnityEngine;

public class mascot_move : MonoBehaviour
{
    public Transform transform;
    public float starry_y;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        starry_y = Mathf.Sin(Time.time);
        transform.position = new Vector3(-12, starry_y, 0);
    }
}
