using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1.5f;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject deathFX;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject scoreFX;

    ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void OnCollisionEnter(Collision collision)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        
    }
    void OnTriggerEnter(Collider other)
    {
        scoreBoard.ScoreHit();
        scoreFX.SetActive(true);
        Invoke("DeactivateScoreFX", 1f);      
    }

    void DeactivateScoreFX()
    {
        scoreFX.SetActive(false);
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
