using UnityEngine;

public class button_move : MonoBehaviour
{
    [SerializeField] float button_x;
    [SerializeField] float button_y;
    [SerializeField] float anim_offset;
    public Transform transform;
    public float floating_y;
    public bool mouseOn = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        floating_y = (float)(Mathf.Sin(Time.time + anim_offset) * 0.2 + button_y);
        transform.position = new Vector3(button_x, floating_y, 0);
        animator.SetBool("isMouseOver", mouseOn);
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
