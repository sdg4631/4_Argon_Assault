using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class BeginGame : MonoBehaviour
 {
	 ParticleSystem beginDust;
	 AudioSource beginJingle;

	float levelLoadDelay = 4f;

	// Use this for initialization
	void Start () 
	{
		beginDust = GetComponent<ParticleSystem>();
		beginJingle = GetComponent<AudioSource>();
	}

	void Update()
	{
		StartGame();
	}

	void StartGame()
	{
		if(Input.GetButtonDown("Jump"))
		{
			beginDust.Play();
			beginJingle.Play();
		 	Invoke("LoadFirstScene", levelLoadDelay);
			
			
		}
	}
	

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
