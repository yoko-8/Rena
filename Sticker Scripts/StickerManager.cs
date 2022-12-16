using UnityEngine;

public class StickerManager : MonoBehaviour
{
    public GameObject trash;

    private Animator animator;
    private bool trashShowing = false;

    public void Awake()
    {
        animator = trash.GetComponent<Animator>();
    }

    public void ShowTrash()
    {
        if (!trashShowing)
        {
            trashShowing = true;
            animator.SetTrigger("showTrash");
            animator.SetBool("TrashShown", true);
        }
    }

    public void HideTrash()
    {
        if (trashShowing)
        {
            trashShowing = false;
            animator.SetTrigger("hideTrash");
            animator.SetBool("TrashShown", false);
        }
    }
}
