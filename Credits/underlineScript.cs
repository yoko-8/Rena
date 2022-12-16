using UnityEngine;

public class underlineScript : MonoBehaviour
{

    public returnToTitle return2title;
    public bool _mouseOn = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _mouseOn = return2title.mouseOn;


        animator.SetBool("isMouseOver", _mouseOn);
    }
}
