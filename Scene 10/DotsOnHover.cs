using UnityEngine;

public class DotsOnHover : MonoBehaviour
{
    public int dotID;
    public DotsController dotsController;
    private void OnMouseOver()
    {
        dotsController.IncrementProgress(dotID);
    }
}
