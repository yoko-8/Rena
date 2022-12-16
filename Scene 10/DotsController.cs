using UnityEngine;

public class DotsController : MonoBehaviour
{
    public CrayonController crayonController;
    public int dotProgress = 0;
    public SpriteRenderer star;
    public AudioClip mouseOverAudio;

    new private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (dotProgress < 11) {
                star.color = Color.clear;
                crayonController.ClearAll();
            }
            dotProgress = 0;
        }
    }

    public void IncrementProgress(int position)
    {
        if (Input.GetMouseButton(0) && position == dotProgress + 1)
        {
            dotProgress++;
            if (mouseOverAudio) audio.PlayOneShot(mouseOverAudio);
            if (dotProgress < 11) star.color = new Color(1, 1, 1, dotProgress * 0.07f);
            else star.color = Color.white;
        }
    }
}
