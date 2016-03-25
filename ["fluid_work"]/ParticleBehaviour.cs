using UnityEngine;
using System.Collections;
using Particle = UnityEngine.ParticleSystem.Particle;

public class ParticleBehaviour : MonoBehaviour {
	Particle[] allParticles;
	Vector3 acceleration;
	float deltaTsq;


	// Use this for initialization
	void Start () {
		ParticleSystem ps = GetComponent<ParticleSystem>();
		allParticles = new Particle[ps.particleCount];
		ps.GetParticles(allParticles);
		ps.SetParticles(allParticles, ps.particleCount);

	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey("up")) {
			acceleration = new Vector3 (100, 0, 0);
		} else {
			acceleration = new Vector3 (0, 0, 0);
		}

		deltaTsq = Mathf.Pow (Time.deltaTime, 2);
		AddForceOnParticles(allParticles);
		transform.Translate(acceleration * deltaTsq);
			
	
	}

	private void AddForceOnParticles(Particle[] particleSys){

		//seems like I can't add forces to indivudal particles for some reason
		//one of the components of unity that is closed off

		for (int i = 0; i < 	particleSys.Length; i++){
			// Here you can do whatever you want with each particle by using _particles[i]
			//mass =volume = size of particle because density of water is 1.
			//veolcity = acceleration * time
			allParticles[i].velocity = acceleration * Time.deltaTime;
		}

		//this.particleSystem.SetParticles(_particles, int size);
	}
}
