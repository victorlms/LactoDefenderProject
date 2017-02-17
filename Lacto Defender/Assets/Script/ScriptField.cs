﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptField : MonoBehaviour {

	public bool onPath = false;
	public bool freeFloor = true;
	public bool walk = false;
	public bool walk2 = false;
	public bool preparaCampo = false;
	public bool cancelaCampo = false;
	public GameObject type;

	// Use this for initialization
	void Start () {

		type = null;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){



		}


	void OnTriggerStay2D(Collider2D other){
		
		
		if (other.CompareTag ("Player") ) {
			
			type = other.gameObject;

			if (other.gameObject.transform.GetComponent<movimentoMoohMooh> () != null) {
				if (other.gameObject.transform.GetComponent<movimentoMoohMooh> ().walking
					&& other.gameObject.transform.GetComponent<movimentoMoohMooh> ().field.gameObject == gameObject) {

					other.gameObject.transform.GetComponent<movimentoMoohMooh> ().walking = false;

					other.gameObject.transform.position = transform.position;
					other.gameObject.transform.GetComponent<spawnPlayerMoohMooh> ().onField = true;
					other.gameObject.transform.GetComponent<movimentoMoohMooh> ().field = null;
					preparaCampo = false;
					cancelaCampo = false;
					other.gameObject.transform.GetComponent<movimentoMoohMooh> ().prepara = false;

				}
			}

			if (other.gameObject.transform.GetComponent<movimentoRaMooh> () != null) {
				if (other.gameObject.transform.GetComponent<movimentoRaMooh> ().walking
				   && other.gameObject.transform.GetComponent<movimentoRaMooh> ().field.gameObject == gameObject) {

					other.gameObject.transform.GetComponent<movimentoRaMooh> ().walking = false;

					other.gameObject.transform.position = transform.position;
					other.gameObject.transform.GetComponent<spawnPlayerRaMooh> ().onField = true;
					other.gameObject.transform.GetComponent<movimentoRaMooh> ().field = null;
					preparaCampo = false;
					cancelaCampo = false;
					other.gameObject.transform.GetComponent<movimentoRaMooh> ().prepara = false;

				}
			}



		}
		else if(other.CompareTag ("Enemy")){
			if(type == null)
				type = other.gameObject;
			}



	}

	void OnTriggerExit2D(Collider2D other){


		if (other.tag == "Player" || other.tag == "Enemy") {

			if (type != null) 
				freeFloor = true;

			type = null;
		}

		preparaCampo = false;
		cancelaCampo = false;

	}
		




	void OnMouseDown(){

		if (freeFloor) {
			preparaCampo = true;
		} else {
			cancelaCampo = true;
		}
	}

}
