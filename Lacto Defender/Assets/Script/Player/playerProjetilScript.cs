using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProjetilScript : MonoBehaviour {

	public float dano;
	public float speed;

	void Start () {

	//	dano = gameObject.transform.parent.GetComponent<StatusPlayer> ().damage;

	}

	void Update () {

		gameObject.transform.Translate (Vector3.right * Time.deltaTime * 1.5f);

	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Enemy") {
			//other.gameObject.transform.GetComponent<StatusEnemy> ().life -= dano;
			Destroy (gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other){

		if (other.gameObject.tag == "Box" && other.gameObject.transform.GetComponentInParent<LineIndentificator>().path[6] == other.gameObject) {
			Destroy (gameObject);
		}

	}

}
