using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class SubmitButton : MonoBehaviour
{
    public Slot slot1;
    public Slot slot2;
    public Slot slot3;
    public Slot slot4;

    public DynamicMusicController controller;

    private void Awake()
    {
        controller = GameObject.Find("BGM Manager").GetComponent<DynamicMusicController>();
    }
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        int[] jingle = new int[4];
        jingle[0] = slot1.sticker != null ? slot1.sticker.noteID : 0;
        jingle[1] = slot2.sticker != null ? slot2.sticker.noteID : 0;
        jingle[2] = slot3.sticker != null ? slot3.sticker.noteID : 0;
        jingle[3] = slot4.sticker != null ? slot4.sticker.noteID : 0;
        //TODO Persist current state

        PlayerPrefs.SetString("jingle", string.Join(",", jingle));
        controller.UpdatePattern();
    }
}
