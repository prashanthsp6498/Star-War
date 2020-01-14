using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] GameObject deathEffect;
    void OnTriggerEnter(Collider trigger)
    {
        deathEffect.SetActive(true);
        print("Triggered");
        SendMessage("FreezeControl");
        Invoke("LoadScene", levelLoadDelay);
    }

    

    private void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
