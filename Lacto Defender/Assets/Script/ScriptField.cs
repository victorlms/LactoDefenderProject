using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptField : MonoBehaviour {

	public bool freeFloor = true;

	public GameObject type;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other){
		type = other.gameObject;
	}

}
