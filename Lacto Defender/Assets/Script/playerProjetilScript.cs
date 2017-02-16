using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProjetilScript : MonoBehaviour {

	public float dano;
	public float speed;

	void Start () {
		

	}

	void Update () {

		gameObject.transform.Translate (Vector3.right * Time.deltaTime * 1.5f);

	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Enemy") {
			other.gameObject.transform.GetComponent<StatusEnemy> ().life -= dano;
			Destroy (gameObject);
		}
	}

}
