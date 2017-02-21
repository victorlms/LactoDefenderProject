using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//VICTOR, CRIEI A VARIÁVEL" PUBLIC FLOAT damage" REFERENTE AO DANO AQUI PRO ALIEN PUXAR E FAZER OS CALCULOS
public class StatusPlayer : MonoBehaviour {

	public float life;
	public float tempoRestante;
	public float damage;
	public bool death;

	void start(){
		death = false;
	
	}


	void FixedUpdate(){

		tempoRestante -= Time.deltaTime/10;

	}

	void OnTriggerStay2D(Collider2D other){

		if (other.tag == "atkEnemy")
			life -= other.transform.GetComponent<StatusEnemy> ().damage;

		if (life < 0 || tempoRestante < 0) {
			death = true;
		}

			if (death) {
			if(other.tag =="Box")
				other.gameObject.transform.GetComponent<ScriptField> ().freeFloor = true;
				Destroy (gameObject);
			}


	}

}