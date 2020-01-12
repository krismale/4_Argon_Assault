﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstScene", 2.0f);
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
