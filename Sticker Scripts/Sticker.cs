using UnityEngine;

public class Sticker : MonoBehaviour
{
    public AudioClip PickUpAudio;
    public AudioClip PutDownAudio;
    public int noteID = 0;
    public CrayonController controller;
    public StickerManager manager;

    private SpriteRenderer sprite_renderer;
    new private AudioSource audio;

    private SpriteRenderer shadow;

    private Vector3 dragOffset;
    private Camera cam;
    public bool onSlot = false;
    public Slot slot;
    public bool shouldRespawn;
    private bool spawned = false;
    public bool mustSlot;

    void Awake()
    {
        cam = Camera.main;

        audio = GetComponent<AudioSource>();

        sprite_renderer = GetComponent<SpriteRenderer>();

        shadow = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        shadow.sprite = sprite_renderer.sprite;
        shadow.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "slot")
        {
            onSlot = true;
            slot = collision.gameObject.GetComponent<Slot>();
        }
        else if (collision.gameObject.tag == "folder")
        {
            Destroy(gameObject);
            if (manager) manager.HideTrash();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "slot")
        {
            onSlot = false;
            slot = null;
        }
    }

    void OnMouseDrag()
    {
        transform.position = GetMousePos() + dragOffset;
    }

    void OnMouseDown()
    {
        dragOffset = transform.position - GetMousePos();

        shadow.enabled = true;
        shadow.sortingLayerName = "Selected Object";
        sprite_renderer.sortingLayerName = "Selected Object";

        if (PickUpAudio)
            audio.PlayOneShot(PickUpAudio);

        if (shouldRespawn && !onSlot)
        {
            GameObject newSticker = Instantiate(gameObject, transform.parent.transform);
            SpriteRenderer newStickerSprite = newSticker.GetComponent<SpriteRenderer>();
            newStickerSprite.sortingLayerName = "Stickers";

            shouldRespawn = false;
            spawned = true;
            if (manager) manager.ShowTrash();
        }

        if (manager && spawned) manager.ShowTrash();

        if (controller) controller.currentColor = Color.clear;
    }

    private void OnMouseUp()
    {
        shadow.enabled = false;

        shadow.sortingLayerName = "Stickers";
        sprite_renderer.sortingLayerName = "Stickers";

        if (PutDownAudio)
            audio.PlayOneShot(PutDownAudio);

        if (onSlot)
        {
            if (slot.sticker != null) Destroy(slot.sticker.gameObject);
            slot.sticker = this;
            transform.position = slot.transform.position;
        }

        if (mustSlot)
        {
            if (!onSlot)
            {
                Destroy(gameObject);
            }
        }

        if (manager && spawned)
        {
            manager.HideTrash();
        }
    }

    Vector3 GetMousePos()
    {
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
