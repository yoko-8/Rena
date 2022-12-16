using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickerCounter : MonoBehaviour
{
    [SerializeField] float init_x;
    [SerializeField] float init_y;
    [SerializeField] float final_x;
    [SerializeField] float final_y;
    public int clickCount;
    public bool nextPage = false;
    public Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clickCount >= 6)
        {
            nextPage = true;
        }

        if (nextPage)
        {
            transform.position = new Vector3((init_x - final_x)/2, (init_y-final_y)/2, 0);
        }
    }

    private void OnMouseDown()
    {
        clickCount++;
    }

}
