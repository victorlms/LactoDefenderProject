using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StatusPlayer : MonoBehaviour {

	float life;
	float tempoRestante;

	public bool death = false;

	void start(){
		life = 10;
	}

	void update(){

		tempoRestante -= Time.deltaTime / 2;

		if (life <= 0 || tempoRestante <= 0) {
			death = true;
		}
	}



	void OnTriggerStay2D(Collider2D other){

		if (other.tag == "atkEnemy")
			life -= other.transform.GetComponent<StatusEnemy> ().damage;

		if (other.tag == "Box") {
			
			if (death) {
				other.gameObject.transform.GetComponent<ScriptField> ().freeFloor = true;
				Destroy (gameObject);
			}
		}

	}

}