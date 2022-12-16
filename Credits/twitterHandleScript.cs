using UnityEngine;

public class twitterHandleScript : MonoBehaviour
{

    public Animator animator;
    public bool mouseOn = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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

    private void OnMouseDown()
    {
        if (gameObject.name == "Blnda")
        {
            Application.OpenURL("https://twitter.com/Belindraw");
        }
        if (gameObject.name == "Daryl")
        {
            Application.OpenURL("https://twitter.com/DarylBarnes_");
        }
        if (gameObject.name == "Lee")
        {
            Application.OpenURL("https://twitter.com/leefan09");
        }
        if (gameObject.name == "Lua")
        {
            Application.OpenURL("https://twitter.com/LuaVLucky");
        }
        if (gameObject.name == "Yoko8")
        {
            Application.OpenURL("https://twitter.com/fox_in_mask");
        }
    }
}
