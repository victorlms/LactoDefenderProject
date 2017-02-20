using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//VICTOR, CRIEI A VARIÁVEL" PUBLIC FLOAT damage" REFERENTE AO DANO AQUI PRO ALIEN PUXAR E FAZER OS CALCULOS
public class StatusPlayer : MonoBehaviour {

	float life;
	float tempoRestante;
	public float damage;
	public bool death;

	void start(){
		death = false;
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