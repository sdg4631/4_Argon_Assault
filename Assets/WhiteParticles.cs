using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteParticles : MonoBehaviour {


	ParticleSystem whiteParticles;

	// Use this for initialization
	void Start() 
	{
		whiteParticles = GetComponent<ParticleSystem>();		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "EndGate" || other.gameObject.tag == "Gold")
		{
			
		}
		else
		{
			whiteParticles.Play();
		}
	}
}
