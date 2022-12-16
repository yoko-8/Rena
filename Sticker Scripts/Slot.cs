using UnityEngine;

public class Slot : MonoBehaviour
{
    public Sticker sticker;

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "sticker")
        {
            sticker = null;
        }
    }

}
