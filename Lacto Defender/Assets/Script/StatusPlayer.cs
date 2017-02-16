using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StatusPlayer : MonoBehaviour {

	public float life = 100f;
	public float damage = 10f;
	public float tempoRestante;

	void start(){
		
			tempoRestante = 100.0f;
		
	}

	void update(){

		tempoRestante = tempoRestante - Time.deltaTime;

		if (tempoRestante <= 0)
			Destroy (gameObject);

	}

}