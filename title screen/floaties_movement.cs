using UnityEngine;

public class floaties_movement : MonoBehaviour
{
    public Transform transform;
    public float rand_x;
    public float y_pos = -30;
    public float rand_speed;

    // Start is called before the first frame update
    void Start()
    {
        rand_x = Random.Range((float)-19.5, (float)19.5);
        rand_speed = Random.Range((float)0.01, (float)0.03);

    }

    // Update is called once per frame
    void Update()
    {
        y_pos += rand_speed;
        transform.position = new Vector3(rand_x, y_pos, 0);

        if (y_pos > 13.5)
        {
            Destroy(gameObject);
        }
    }
}
