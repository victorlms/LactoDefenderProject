using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptCampo : MonoBehaviour {

	public bool disponibilidade = true;

	public GameObject tipo;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other){
		tipo = other.gameObject;
	}

}
