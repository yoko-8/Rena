using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sticker_jiggle : MonoBehaviour
{
    public Transform transform;
    public float jiggle_z;
    public bool mouseOn = false;
    public bool shake = false;
    [SerializeField] float stickerTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stickerTimer += Time.deltaTime;
        if (stickerTimer < 5)
        {
            shake = false;
        }
        else if (stickerTimer >=5 && stickerTimer < 5.6)
        {
            shake = true;
        }
        else if (stickerTimer >= 5.6)
        {
            stickerTimer = 0;
        }


        if (shake == true && mouseOn == false)
        {
            jiggle_z = (float)(Mathf.Sin(Time.time * 25) * 8);
            transform.rotation = Quaternion.Euler(0, 0, jiggle_z);
        }
    }

    void OnMouseOver()
    {
        mouseOn = true;
    }

    void OnMouseExit()
    {
        mouseOn = false;
    }
}
