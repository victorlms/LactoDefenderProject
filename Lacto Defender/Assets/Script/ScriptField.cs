using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptField : MonoBehaviour {

	public bool freeFloor = true;
	public bool walk = false;
	public bool walk2 = false;
	public bool preparaCampo = false;
	public bool cancelaCampo = false;

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		
	}

	void OnTriggerStay2D(Collider2D other){
	}

	void OnTriggerExit2D(Collider2D other){

	}
		




	void OnMouseDown(){

		if (freeFloor) {
			preparaCampo = true;
		} else {
			cancelaCampo = true;
		}
	}

}
