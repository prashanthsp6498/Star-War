using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Invoke("LoadNextScene", 5f);
    }
    
    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
    
    void Update()
    {

    }
}
