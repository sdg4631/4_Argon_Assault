using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1.5f;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject deathFX;

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        Invoke("ReloadScene", levelLoadDelay);

    }

    private void ReloadScene() // string referenced
    {
        SceneManager.LoadScene(1);
    }
}
