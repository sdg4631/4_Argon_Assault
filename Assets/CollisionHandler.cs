using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1.5f;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject deathFX;
    

    ScoreBoard scoreBoard; // 

    public Rigidbody rb;
    AudioSource scoreAudio;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        rb = GetComponent<Rigidbody>();
        scoreAudio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        
    }
    void OnTriggerEnter(Collider other)
    {
        scoreBoard.ScoreHit();

        if(scoreAudio.isPlaying)
        {
            scoreAudio.Stop();
            scoreAudio.Play();
        }
        else
        {
            scoreAudio.Play();
        }
        
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        Invoke("ReloadScene", levelLoadDelay);

        // ragdoll after collision
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }

    private void ReloadScene() // string referenced
    {
        SceneManager.LoadScene(1);
    }
}
