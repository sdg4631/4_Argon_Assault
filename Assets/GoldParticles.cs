using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldParticles : MonoBehaviour 
{

	ParticleSystem goldParticles;

	// Use this for initialization
	void Start() 
	{
		goldParticles = GetComponent<ParticleSystem>();		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Gold")
		{
			goldParticles.Play();
		}
	}
}
