﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class goToCredits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("17-Credits");
    }
}
