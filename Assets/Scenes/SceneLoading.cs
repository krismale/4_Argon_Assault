using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    [SerializeField] float loadTime = 2f;
    [SerializeField] bool loadNewSceneImmediately = true;

    // Start is called before the first frame update
    void Start()
    {
        if(loadNewSceneImmediately)
        {
            Invoke("LoadFirstScene", 2.0f);
        }
        
    }

    void LoadFirstScene()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        if (SceneManager.sceneCountInBuildSettings > currentLevelIndex + 1)
        {
            SceneManager.LoadScene(currentLevelIndex + 1);
        }
        
    }
}
