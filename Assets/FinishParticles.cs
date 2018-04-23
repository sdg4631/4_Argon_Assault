using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishParticles : MonoBehaviour {


	ParticleSystem finishParticles;

	// Use this for initialization
	void Start() 
	{
		finishParticles = GetComponent<ParticleSystem>();		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "EndGate")
		{
			finishParticles.Play();
		}
	}
}
