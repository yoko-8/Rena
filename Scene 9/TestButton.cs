using System.Collections;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    public Slot slot1;
    public Slot slot2;
    public Slot slot3;
    public Slot slot4;

    new private AudioSource audio;
    private bool isPlaying = false;

    private void OnMouseDown()
    {
        if (isPlaying) StopCoroutine("PlayJingle");
        StartCoroutine("PlayJingle");
    }

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    IEnumerator PlayJingle()
    {
        isPlaying = true;
        if (slot1.sticker != null) audio.PlayOneShot(slot1.sticker.PickUpAudio);
        yield return new WaitForSeconds(.3f);
        if (slot2.sticker != null) audio.PlayOneShot(slot2.sticker.PickUpAudio);
        yield return new WaitForSeconds(.3f);
        if (slot3.sticker != null) audio.PlayOneShot(slot3.sticker.PickUpAudio);
        yield return new WaitForSeconds(.3f);
        if (slot4.sticker != null) audio.PlayOneShot(slot4.sticker.PickUpAudio);
        isPlaying = false;
    }
}
