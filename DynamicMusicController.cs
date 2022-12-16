using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DynamicMusicController : MonoBehaviour
{
    public AudioClip note1a;
    public AudioClip note2a;
    public AudioClip note3a;
    public AudioClip note4a;
    public AudioClip note5a;

    public AudioClip note1b;
    public AudioClip note2b;
    public AudioClip note3b;
    public AudioClip note4b;
    public AudioClip note5b;

    public bool dynamic = false;
    public bool fade = false;
    new private AudioSource audio;
    private string track;
    private int[] pattern;

    private class Note
    {
        public int Type;
        public int Slot;

        public Note(int type, int slot)
        {
            Type = type;
            Slot = slot;
        }
    }
    // <track, <offset, <type, slot>>>
    private readonly Dictionary<string, Dictionary<float, Note>> beatmap = new Dictionary<string, Dictionary<float, Note>>
    {
        {"sampleloop", new Dictionary<float, Note>
            {
                { 3.000f, new Note(0, 0) },
                { 3.125f, new Note(0, 1) },
                { 3.250f, new Note(0, 2) },
                { 3.375f, new Note(0, 3) },
                { 4.000f, new Note(1, 0) },
                { 5.000f, new Note(1, 1) },
                { 6.000f, new Note(1, 2) },
                { 7.000f, new Note(1, 3) }
            }
        },
        {"childhood2", new Dictionary<float, Note>
            {
                { 15.000f, new Note(0, 0) },
                { 15.250f, new Note(0, 1) },
                { 15.500f, new Note(0, 2) },
                { 15.750f, new Note(0, 3) },
                { 26.000f, new Note(1, 0) },
                { 26.376f, new Note(1, 1) },
                { 26.751f, new Note(1, 2) },
                { 27.000f, new Note(1, 3) },
                { 30.000f, new Note(1, 0) },
                { 30.378f, new Note(1, 1) },
                { 30.753f, new Note(1, 2) },
                { 31.000f, new Note(1, 3) }
            }
        },
        {"rena", new Dictionary<float, Note>
            {
                { 13.061f, new Note(0, 0) },
                { 13.877f, new Note(0, 1) },
                { 14.693f, new Note(0, 2) },
                { 15.510f, new Note(0, 3) },
                { 16.326f, new Note(0, 0) },
                { 16.734f, new Note(0, 1) },
                { 17.142f, new Note(0, 2) },
                { 17.551f, new Note(0, 3) },
                { 19.591f, new Note(0, 0) },
                { 20.000f, new Note(0, 1) },
                { 20.408f, new Note(0, 2) },
                { 20.816f, new Note(0, 3) },
                { 21.224f, new Note(0, 0) },
                { 22.040f, new Note(0, 1) },
                { 22.857f, new Note(0, 2) },
                { 26.122f, new Note(0, 0) },
                { 26.530f, new Note(0, 1) },
                { 26.734f, new Note(0, 2) },
                { 27.142f, new Note(0, 3) },
                { 27.551f, new Note(0, 0) },
                { 28.163f, new Note(0, 1) },
                { 28.571f, new Note(0, 2) },
                { 28.979f, new Note(0, 3) },
                { 31.836f, new Note(0, 0) },
                { 32.040f, new Note(0, 1) },
                { 32.244f, new Note(0, 2) },
                { 32.448f, new Note(0, 3) },
                { 32.653f, new Note(0, 0) },
                { 33.061f, new Note(0, 1) },
                { 33.469f, new Note(0, 2) },
                { 33.877f, new Note(0, 3) },
                { 35.918f, new Note(0, 0) },
                { 36.734f, new Note(0, 1) },
                { 37.551f, new Note(0, 2) },
                { 38.367f, new Note(0, 3) },
                { 39.183f, new Note(0, 0) }
            }
        },
        {"future2", new Dictionary<float, Note>
            {
                { 18.000f, new Note(0, 0) },
                { 18.250f, new Note(0, 1) },
                { 18.500f, new Note(0, 2) },
                { 18.750f, new Note(0, 3) },
                { 26.000f, new Note(0, 0) },
                { 26.250f, new Note(0, 1) },
                { 26.500f, new Note(0, 2) },
                { 26.750f, new Note(0, 3) },
                { 34.000f, new Note(0, 0) },
                { 34.250f, new Note(0, 1) },
                { 34.500f, new Note(0, 2) },
                { 34.750f, new Note(0, 3) },
                { 42.000f, new Note(0, 0) },
                { 42.250f, new Note(0, 1) },
                { 42.500f, new Note(0, 2) },
                { 42.750f, new Note(0, 3) }
            }
        },
        {"title", new Dictionary<float, Note>
            {
                { 5.714f, new Note(0, 0) },
                { 7.500f, new Note(0, 1) },
                { 8.035f, new Note(0, 2) },
                { 8.571f, new Note(0, 3) },
                { 10.714f, new Note(0, 0) },
                { 11.428f, new Note(0, 0) },
                { 13.214f, new Note(0, 1) },
                { 13.750f, new Note(0, 2) },
                { 14.285f, new Note(0, 3) },
                { 16.428f, new Note(0, 0) },
                { 17.142f, new Note(0, 0) },
                { 18.928f, new Note(0, 1) },
                { 19.464f, new Note(0, 2) },
                { 20.000f, new Note(0, 3) },
                { 21.428f, new Note(0, 0) },
                { 22.857f, new Note(0, 1) },
                { 24.285f, new Note(0, 2) },
                { 25.714f, new Note(0, 3) }
            } 
        }
    };

    private AudioClip[,] notes;

    private void Awake()
    {
        int sceneID = SceneManager.GetActiveScene().buildIndex;
        if (sceneID == 3 || sceneID == 7 || sceneID == 11)
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        audio = GetComponent<AudioSource>();
        notes = new AudioClip[2, 5]
        {
            {note1a, note2a, note3a, note4a, note5a },
            {note1b, note2b, note3b, note4b, note5b }
        };
        track = audio.clip.name;
        pattern = GetUserPattern();
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        audio = GetComponent<AudioSource>();
        if (scene.buildIndex == 8)
        {
            dynamic = true;
            fade = true;
        }
        if (scene.buildIndex == 12)
        {
            dynamic = true;
            UpdatePattern();
        }
        if (scene.buildIndex == 5 || scene.buildIndex == 9 || scene.buildIndex == 16)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if (dynamic && pattern.Length > 0)
        {
            StartDynamicNotes(0f);
        }
    }
    private void Update()
    {
        if (fade && audio.volume > .4f) audio.volume -= .001f;
    }
    public void UpdatePattern()
    {
        if (audio == null)
        {
            audio = GetComponent<AudioSource>();
            track = audio.clip.name;
            notes = new AudioClip[2, 5]
            {
                {note1a, note2a, note3a, note4a, note5a },
                {note1b, note2b, note3b, note4b, note5b }
            };
        }
        StopAllCoroutines();
        pattern = GetUserPattern();
        StartDynamicNotes(audio.clip.length - audio.time);
    }
    private int[] GetUserPattern()
    {
        string jingle = PlayerPrefs.GetString("jingle");
        if (jingle.Length == 0) return new int[] { 0, 0, 0, 0 };
        return Array.ConvertAll<string, int>(jingle.Split(','), s => int.Parse(s));
    }
    public void StartDynamicNotes(float offset)
    {
        float interval = audio.clip.length;
        foreach (var note in beatmap[track])
        {
            float adjustedOffset = note.Key + offset;
            if (adjustedOffset > interval) adjustedOffset -= interval;
            int pitch = pattern[note.Value.Slot] - 1;
            if (pitch >= 0) StartCoroutine(PlayNote(notes[note.Value.Type, pitch], interval, adjustedOffset));
        }
    }
    private IEnumerator PlayNote(AudioClip note, float interval, float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        while (true)
        {
            audio.PlayOneShot(note);
            yield return new WaitForSecondsRealtime(interval);
        }
    }
}
