﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptField : MonoBehaviour {

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
		}
		else if(other.CompareTag ("Enemy")){
				type = other.gameObject;
			}
	}

	void OnTriggerExit2D(Collider2D other){

			
		if (other.tag == "Player" || other.tag == "Enemy") 
			type = null;

	}
		




	void OnMouseDown(){

		if (freeFloor) {
			preparaCampo = true;
		} else {
			cancelaCampo = true;
		}
	}

}
