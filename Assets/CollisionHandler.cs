using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum State { Playing, Dying, Finished}

public class CollisionHandler : MonoBehaviour
{
    State state = State.Playing;

    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 2f;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject deathFX;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject windFX;
    [Tooltip("Audio when level finished")] [SerializeField] GameObject finishAudio;
    
  

    ScoreBoard scoreBoard; // 

    public Rigidbody rb;
    AudioSource scoreAudio;
    AudioSource goldScoreAudio;
    
    

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        rb = GetComponent<Rigidbody>();
        AudioSource[] audiosource = GetComponents<AudioSource>();
        scoreAudio = audiosource[0];
        goldScoreAudio = audiosource[1];
    }

    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Finished)
        {
            state = State.Dying;
            StartDeathSequence();
            deathFX.SetActive(true);
        }
        else
        {           
            SendMessage("DisableControls");
            Ragdoll();
            Destroy(windFX);
        }

        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EndGate")
        {
            state = State.Finished;
            FinishLevelSequence();
        }
        else if(state == State.Dying)
        {

        }
        else
        {
            if(other.gameObject.tag == "Gold")
            {
                GoldScore();

                windFX.SetActive(true);
            }
            else
            {
                Score();
                windFX.SetActive(true);
            }
        }
    }

    private void GoldScore()
    {
        scoreBoard.ScoreHit();
        scoreBoard.ScoreHit();
        scoreBoard.ScoreHit();
        scoreBoard.ScoreHit();
        scoreBoard.ScoreHit();
        
        if (goldScoreAudio.isPlaying)
        {
            goldScoreAudio.Stop();
            goldScoreAudio.Play();
        }
        else
        {
            goldScoreAudio.Play();
        }
    }

    private void Score()
    {
        scoreBoard.ScoreHit();

        if (scoreAudio.isPlaying)
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
        SendMessage("DisableControls");
        Invoke("ReloadScene", levelLoadDelay);
        Ragdoll();
    }

    private void Ragdoll()
    {
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }

    private void ReloadScene() // string referenced
    {
        SceneManager.LoadScene(1);
    }

    private void FinishLevelSequence()
    {
        finishAudio.SetActive(true);
        float timeToReloadSplash = 15f;       
        Invoke("ReloadSplash", timeToReloadSplash);
        
    }

    private void ReloadSplash()
    {
        SceneManager.LoadScene(0);
    }
}
