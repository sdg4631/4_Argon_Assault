using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

	// Use this for initialization
	void Start()
    {
        
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}

    private void Awake()
    {
        int numOfMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        // if more than one music player in scene
        if (numOfMusicPlayers > 1)
            // destroy ourselves
            Destroy(gameObject);           
        else
        DontDestroyOnLoad(gameObject);
    }
}
