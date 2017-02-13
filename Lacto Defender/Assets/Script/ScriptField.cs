using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptField : MonoBehaviour {

	public bool freeFloor = true;
	public bool walk = false;
	public bool walk2 = false;
	Card player;
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
		type = other.gameObject;
	}

	void OnTriggerExit2D(Collider2D other){
		type = null;
	}

}
