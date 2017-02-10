using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptProjetil : MonoBehaviour {

	public float dano = 10;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {


	//	transform.position.x++;

	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Enemy") {

			StatusEnemy status = other.gameObject.GetComponent<StatusEnemy> ();
			status.life -= dano;

		}

	}
}
