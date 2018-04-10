using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

	// Use this for initialization
	void Start()
    {
        Invoke("LoadFirstScene", 10f);
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
